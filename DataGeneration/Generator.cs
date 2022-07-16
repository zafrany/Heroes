using Heroes.Data;
using Heroes.Models;
using Heroes.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.DataGeneration
{
    
    public class Generator
    {   
        private readonly HeroesContext _context;
        private readonly UserManager<User> _userManager;

        public Generator(HeroesContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async void generate()
        {
            if(_context.Heroes.ToList().Count == 0)
            {
                var user1 = new User
                {
                    Id = "1",
                    Email = "moshe@gmail.com",
                    UserName = "moshe@gmail.com",
                };

                var user2 = new User
                {
                    Id = "3",
                    Email = "moshe2@gmail.com",
                    UserName = "moshe2@gmail.com",
                };

                

                var hero = new Hero
                {
                    Name = "Hero 1",
                    Ability = "Attacker",
                    StartedTrainingDate = DateTime.Now,
                    SuitColors = "Red, Blue, Green",
                    StartingPower = 100,
                    CurrentPower = 105,
                    User = user1,
                };
                _context.Heroes.Add(hero);

                var hero2 = new Hero
                {
                    Name = "Hero 2",
                    Ability = "Defender",
                    StartedTrainingDate = DateTime.Now,
                    SuitColors = "Red, Blue, Green",
                    StartingPower = 100,
                    CurrentPower = 105,
                    User = user2,
                };
                _context.Heroes.Add(hero2);

                var hero3 = new Hero
                {
                    Name = "Hero 3",
                    Ability = "Attacker",
                    StartedTrainingDate = DateTime.Now,
                    SuitColors = "Red, Blue, Green",
                    StartingPower = 100,
                    CurrentPower = 105,
                    User = user1,
                };
                _context.Heroes.Add(hero3);

                var hero4 = new Hero
                {
                    Name = "Hero 4",
                    Ability = "Defender",
                    StartedTrainingDate = DateTime.Now,
                    SuitColors = "Red, Blue, Green",
                    StartingPower = 100,
                    CurrentPower = 105,
                    User = null,
                };
                _context.Heroes.Add(hero4);
                _context.SaveChanges();

                await _userManager.AddPasswordAsync(user1, "1234+-Abc");
                await _userManager.AddPasswordAsync(user2, "1234+-Abc");
            }   
            return;
        }
    }
}
