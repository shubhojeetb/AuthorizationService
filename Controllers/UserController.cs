using AuthorizationService.Models;
using AuthorizationService.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Controllers
{
    [Authorize]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserAuthProvider _userProvider;
        
        public UserController(IUserAuthProvider userProvider)
        {
            _userProvider = userProvider;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]

        public IActionResult Authenticate([FromBody] User model)
        {
            var user = _userProvider.AuthenticateProvider(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest(new User { Id = 0, Username=null, Password=null, Token = "unauthorized" }); ;
            }
            return Ok(user);
        }
    }
}
