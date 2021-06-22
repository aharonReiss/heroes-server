using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroesProgect.Models;

namespace HeroesProgect.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Ability Ability { get; set; }
        public User Guid  { get; set; }
        public int GuidId { get; set; }
        public DateTime? StartedTrain { get; set; }
        public string SuitColor { get; set; }
        public double? StartingPower { get; set; }
        public double? CurrentPower { get; set; }
        public DateTime? CurrentDate { get; set; }
        public int? TimesTrainToday { get; set; }
    }
    public enum Ability
    {
        attacker,
        defender
    }
}
