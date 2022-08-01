using Heroes.Data;
using Heroes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        public IQueryable<Hero> GetHeroesByUserId(string userId)
        {
            return _context.Heroes.Where(hero => hero.User.Id == userId);           
        }

        public IQueryable<Hero> GetMyHeroes(string id)
        {
            Boolean dataBaseUpdateNeeded = false;
            var heroList = _context.Heroes.Where(hero => hero.User.Id == id);
            foreach(Hero hero in heroList)
            {
                if((DateTime.Now - hero.LastTrainingDate).TotalDays >= 1)
                {
                    dataBaseUpdateNeeded = true;
                    hero.RemainingTrains = 5;
                }
                    
            }
            if(dataBaseUpdateNeeded)
                _context.SaveChanges();
            return heroList;
        }

        public IQueryable<Hero> GetHeroByHeroId(int heroId)
        {
            return _context.Heroes.Include(hero => hero.User).Where(hero => hero.Id.ToString() == heroId.ToString());
        }

        public Hero TrainHero(Hero hero)
        {
            Random rand = new Random();
            hero.RemainingTrains--;
            hero.CurrentPower *= ((double)rand.Next(0, 10) /100 + 1);
            hero.LastTrainingDate = DateTime.Now;
            _context.SaveChanges();
            return hero;
        }
    }
}
