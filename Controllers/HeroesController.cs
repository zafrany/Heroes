using Heroes.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Heroes.Models;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using Heroes.Logger;

namespace Heroes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public HeroesController(IHeroRepository heroRepository, IAccountRepository accountRepository, IMapper mapper, ILoggerManager logger)
        {
            _heroRepository = heroRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _logger = logger;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await _heroRepository.GetAllHeroes().ToListAsync();
            var result = _mapper.Map<List<Hero>>(heroes);

            var stringRes = "";
            foreach (Hero hero in heroes)
            {
                stringRes += hero.ToString();
            }
            _logger.LogInfo("LogInfo: get my heroes return value:" + "\n" + stringRes + "\n");

            return Ok(result);
        }

        [HttpGet("myHeroes")]
        public async Task<IActionResult> GetMyHeroes()
        {
            string id = _accountRepository.GetUserId(User);
            var heroes = await _heroRepository.GetMyHeroes(id).ToListAsync();

            var stringRes = "";

            foreach(Hero hero in heroes)
            {
                stringRes += hero.ToString() + " ";
            }
            _logger.LogInfo("LogInfo: get my heroes return value:" + "\n" + stringRes + "\n");
            _logger.LogInfo("Requesters Id (from token) = " + id);

            return Ok(heroes);
        }

        [HttpPatch(":{heroId}/RemainingTrains")]
        public async Task<IActionResult> TrainHero([FromRoute] int heroId)
        {
            string userId = _accountRepository.GetUserId(User);
            var hero = await _heroRepository.GetHeroByHeroId(heroId).ToListAsync();
            var res = hero.FirstOrDefault();
            if (res.User == null || res.User.Id != userId || res.RemainingTrains <= 0)
            {
                return BadRequest();
            }
            
            res = _heroRepository.TrainHero(res);
            return Ok(res);

        }
    }
}
