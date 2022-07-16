using Heroes.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroRepository _heroRepository;

        public HeroesController(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await _heroRepository.GetAllHeroes().ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroesByUserId([FromRoute]int id)
        {
            var heroes = await _heroRepository.GetHeroesByUserId(id).ToListAsync();
            return Ok(heroes);
        }
    }
}
