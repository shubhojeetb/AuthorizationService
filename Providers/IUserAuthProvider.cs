using AuthorizationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Providers
{
    public interface IUserAuthProvider
    {
        public User AuthenticateProvider(string username, string password);
        
    }
}
