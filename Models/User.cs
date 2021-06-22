using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HeroesProgect.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string token { get; set; }
    }
}
