using Heroes.Data;
using Heroes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroesContext _context;

        public HeroRepository(HeroesContext context)
        {
            _context = context;
        }

        public IQueryable<Hero> GetAllHeroes()
        {
            return _context.Heroes.Where(hero => true);
        }

        public IQueryable<Hero> GetHeroesByUserId(int userId)
        {
            return _context.Heroes.Where(hero => hero.User.Id == userId.ToString());
        }
    }
}
