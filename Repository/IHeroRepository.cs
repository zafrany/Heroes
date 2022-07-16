using Heroes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Repository
{
    public interface IHeroRepository
    {
        IQueryable<Hero> GetAllHeroes();
        IQueryable<Hero> GetHeroesByUserId(int userId);
    }
}
