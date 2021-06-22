using HeroesProgect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesProgect.Services
{
    public class HeroService : IHeroService
    {
        DataContext context;
        public HeroService(DataContext dc)
        {
            context = dc;
        }

        public bool Play(int id)
        {  
            var hero = context.heros.SingleOrDefault(h => h.Id == id);
            DateTime heroCurrentDate = hero.CurrentDate != null ? (DateTime)hero.CurrentDate : DateTime.Now;
            DateTime currentD = DateTime.Now;
            if(hero.CurrentDate == null || heroCurrentDate.ToString("MM/dd/yyyy") != currentD.ToString("MM/dd/yyyy"))
            {
                this.StartToPlay(hero);
                /*DateTime now = DateTime.Now;
                hero.CurrentDate = now;
                hero.TimesTrainToday = 1;
                hero.CurrentPower = this.GetRandomNumber((double)hero.CurrentPower);
                if(hero.StartedTrain is null)
                {
                    hero.StartedTrain = now;
                }*/
                context.SaveChanges();
                return true;
            }
            else if(hero.TimesTrainToday < 5)
            {
                /* hero.TimesTrainToday += 1;
                 hero.CurrentPower = this.GetRandomNumber((double)hero.CurrentPower);*/
                this.ContinuesToplay(hero);
                context.SaveChanges();
                return true;
            }
            throw new Exception("canot can play");
        }

        void ContinuesToplay(Hero hero)
        {
            hero.TimesTrainToday += 1;
            hero.CurrentPower = this.GetRandomNumber((double)hero.CurrentPower);
        }

        void StartToPlay(Hero hero)
        {
            DateTime now = DateTime.Now;
            hero.CurrentDate = now;
            hero.TimesTrainToday = 1;
            hero.CurrentPower = this.GetRandomNumber((double)hero.CurrentPower);
            if (hero.StartedTrain is null)
            {
                hero.StartedTrain = now;
            }
        }

        public double GetRandomNumber(double currentPower)
        {
            Random random = new Random();
            double result = random.NextDouble() * ((currentPower / 10) - 0) + currentPower;
            return result;
        }
    }
}
