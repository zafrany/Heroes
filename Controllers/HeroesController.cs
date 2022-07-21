using Heroes.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Heroes.Controllers
{
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

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroesByUserId([FromRoute]int id)
        {
            var heroes = await _heroRepository.GetHeroesByUserId(id).ToListAsync();
            return Ok(heroes);
        }

        [Authorize]
        [HttpGet("myHeroes")]
        public async Task<IActionResult> GetMyHeroes()
        {
            string id = _accountRepository.GetUserId(User);
            var heroes = await _heroRepository.GetMyHeroes(id).ToListAsync();
            return Ok(heroes);
        }
    }
}
