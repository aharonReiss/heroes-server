using HeroesProgect.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HeroesProgect.Services
{
    public class UserAuthenticatioServise : IUserAuthentication
    {
        private DataContext context;

        public UserAuthenticatioServise(DataContext ctx)
        {
            context = ctx;
        }
        public bool IsValidPassword(string password)
        {
            if (password.Count(x => !Char.IsLetterOrDigit(x)) != 1)
            {
                throw new Exception("need one Special character");
            }
            if (password.Count(x => Char.IsNumber(x)) != 1)
            {
                throw new Exception("need one digit character");
            }
            if (password.Count(x => Char.IsUpper(x)) != 1)
            {
                throw new Exception("need one capital letter");
            }
            return true;
        }

        private string BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        public string HashPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }

        public bool IsUserExist(string mail)
        {
            var userInUse = context.users.SingleOrDefault(u => u.Email == mail);
            if (userInUse != null)
            {
                return true;
            }
            return false;
        }
        public bool VerifyPassword(LoginModel loginBinding)
        {
            var user = context.users.SingleOrDefault(u => u.Email == loginBinding.UserName);
            if (BCrypt.Net.BCrypt.Verify(loginBinding.Password, user.Password))
            {
                return true;
            }
            return false;
        }
    }
}
