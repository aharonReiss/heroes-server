using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesProgect.Models;
using Microsoft.AspNetCore.Authorization;

namespace HeroesProgect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HeroController : ControllerBase
    {
        private DataContext context;
        private IHeroService _heroService;
        public HeroController(DataContext dc,IHeroService hs)
        {
            context = dc;
            _heroService = hs;
        }
        [HttpPut]
        public IActionResult CreateHero([FromBody] HeroCreateModel hero)
        {
            var guid = context.users.SingleOrDefault(u => u.Id == hero.GuidId);
            context.heros.Add(new Hero
            {
                Name = hero.Name,
                Ability = hero.Ability == "attacker" ? Ability.attacker : Ability.defender,
                SuitColor = hero.SuitColor,
                CurrentDate = null,
                CurrentPower = hero.StartingPower,
                StartingPower = hero.StartingPower,
                Guid = guid,
                StartedTrain = null,
                TimesTrainToday = null
            });
            context.SaveChanges();
            return Ok(guid);
        }

        [HttpGet("{id}")]
        public IActionResult GetHerosByTrainerId(int id)
        {
            var heros = context.heros.Where(h => h.GuidId == id).OrderByDescending(h => h.CurrentPower);
            return Ok(heros);
        }

        [HttpGet("heroId/{id}")]
        public IActionResult GetHerosByHeroId(int id)
        {
            var hero = context.heros.SingleOrDefault(h => h.Id == id);
            return Ok(hero);
        }
        [HttpPost("play/{id}")]
        public IActionResult Play(int id)
        {
            return Ok(_heroService.Play(id));
        }
    }
}
