using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationService.Models;

namespace AuthorizationService.Repository
{
    public interface IUserAuthRepository
    {
        User Authenticate(string username, string password);
        
    }
}
