using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesProgect.Models
{
    public interface IHeroService
    {
        public bool Play(int id);
        public double GetRandomNumber(double currentPower);
    }
}
