using AuthorizationService.Models;
using AuthorizationService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Providers
{
    public class UserAuthProvider : IUserAuthProvider
    {
        private readonly IUserAuthRepository _userAuthRepo;
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UserAuthProvider));

        public UserAuthProvider(IUserAuthRepository userAuthRepo)
        {
            _userAuthRepo = userAuthRepo;
        }
        public User AuthenticateProvider(string username, string password)
        {
            _log4net.Info(" AuthenticateProvider method of UserAuthProvider Called ");
            User authUser = new User();
            authUser  = _userAuthRepo.Authenticate(username,password);
            return authUser;
        }
    }
}
