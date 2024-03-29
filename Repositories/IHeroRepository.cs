﻿using Heroes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Repository
{
    public interface IHeroRepository
    {
        IQueryable<Hero> GetAllHeroes();
        IQueryable<Hero> GetHeroesByUserId(string userId);
        IQueryable<Hero> GetMyHeroes(string userClaims);
        IQueryable<Hero> GetHeroByHeroId(int heroId);
        Hero TrainHero(Hero hero);
    }
}
