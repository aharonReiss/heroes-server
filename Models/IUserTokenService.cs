using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesProgect.Models
{
    public interface IUserTokenService
    {
        string CreateToken(string username);
    }
}
