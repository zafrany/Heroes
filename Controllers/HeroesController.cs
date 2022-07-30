using Heroes.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Heroes.Models;
using System.Linq;

namespace Heroes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IAccountRepository _accountRepository;

        public HeroesController(IHeroRepository heroRepository, IAccountRepository accountRepository)
        {
            _heroRepository = heroRepository;
            _accountRepository = accountRepository;        
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await _heroRepository.GetAllHeroes().ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("myHeroes")]
        public async Task<IActionResult> GetMyHeroes()
        {
            string id = _accountRepository.GetUserId(User);
            var heroes = await _heroRepository.GetMyHeroes(id).ToListAsync();
            return Ok(heroes);
        }

        [HttpPatch(":{heroId}/RemainingTrains")]
        public async Task<IActionResult> TrainHero([FromRoute] int heroId)
        {
            string userId = _accountRepository.GetUserId(User);
            var hero = await _heroRepository.GetHeroByHeroId(heroId).ToListAsync();
            var res = hero.FirstOrDefault();
            if (res.User.Id != userId || res.RemainingTrains <= 0)
            {
                return BadRequest();
            }
            
            res = _heroRepository.TrainHero(res);
            return Ok(res);

        }
    }
}
