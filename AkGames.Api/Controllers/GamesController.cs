using AkGames.Api.Dtos;
using AkGames.Api.Repos.GamesRepos;
using Microsoft.AspNetCore.Mvc;

namespace AkGames.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepo _gamesService;

        public GamesController(IGamesRepo gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var games = _gamesService.GetAll();
            return Ok(games);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var game = _gamesService.GetById(id);

            if (game is null)
                return NotFound();

            return Ok(game);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateGameFormDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _gamesService.Create(model);

            return Ok(model);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromForm] EditGameFormDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var game = await _gamesService.Update(model);

            if (game is null)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _gamesService.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}