using Heroes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Heroes.Data
{
    public class HeroesContext : IdentityDbContext<User>
    {
        public HeroesContext(DbContextOptions<HeroesContext> options) : base(options)
        {

        }

        public DbSet<Models.Hero> Heroes { get; set; }
    }
}
