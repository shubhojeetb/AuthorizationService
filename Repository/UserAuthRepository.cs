using AuthorizationService.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace AuthorizationService.Repository
{
    public class UserAuthRepository : IUserAuthRepository
    {
        UserContext db = new UserContext();
        private readonly AppSettings _appSettings;
        public UserAuthRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public User Authenticate(string username, string password)
        {
            var user=new User();
            user = db.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            
            if (user == null)
            {
                return null;
            }

            //if user found generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user; 
        }

    }
}
