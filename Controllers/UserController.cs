using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesProgect.Models;

namespace HeroesProgect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserAuthentication _userAuthentication;
        private DataContext context;
        private IUserTokenService _userToken;
        public UserController(IUserAuthentication userAuth,DataContext dc,IUserTokenService userToken)
        {
            _userAuthentication = userAuth;
            _userToken = userToken;
            context = dc;
        }
        [HttpPut]
        public IActionResult SignUp([FromBody] User user)
        {
            if(_userAuthentication.IsUserExist(user.Email))
            {
                return BadRequest("user exist");
            }
            if(!_userAuthentication.IsValidPassword(user.Password))
            {
                return BadRequest("no good password");
            }
            user.Password = _userAuthentication.HashPassword(user.Password);
            context.users.Add(user);
            context.SaveChanges();
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = _userAuthentication.IsUserExist(loginModel.UserName);
            if(!user)
            {
                return BadRequest("no user exist");
            }
            if(!_userAuthentication.VerifyPassword(loginModel))
            {
                return BadRequest("wrong password");
            }
            var token = _userToken.CreateToken(loginModel.UserName);
            var u = context.users.SingleOrDefault(u => u.Email == loginModel.UserName);
            return Ok(new Token() { token = token,Id =  u.Id});
        }   
    }
}
