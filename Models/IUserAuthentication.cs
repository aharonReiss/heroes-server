using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesProgect.Models;

namespace HeroesProgect.Models
{
    public interface IUserAuthentication
    {
        bool IsValidPassword(string password);
        bool VerifyPassword(LoginModel loginModel);
        string HashPassword(string password);
       // string CreateToken(string username);
        bool IsUserExist(string mail);
    }
}
