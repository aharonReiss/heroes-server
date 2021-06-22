using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HeroesProgect.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
           : base(opts) { }
        public DbSet<User> users { get; set; }
        public DbSet<Hero> heros { get; set; }
        public int TimesTrainToday { get; internal set; }
    }
}
