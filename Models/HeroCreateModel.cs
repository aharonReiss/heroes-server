using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HeroesProgect.Models
{
    public class HeroCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ability { get; set; }
        public int GuidId { get; set; }
        public string SuitColor { get; set; }
        public double StartingPower { get; set; }
    }
}
