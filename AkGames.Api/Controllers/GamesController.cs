using AkGames.Api.Core.Models;
using AkGames.Api.Dtos;
using AkGames.Api.Repos.GamesRepos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkGames.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesRepo _gamesService;
        private readonly IMapper _mapper;

        public GamesController(IGamesRepo gamesService, IMapper mapper)
        {
            _gamesService = gamesService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var games = _mapper.Map<IList<GameGitDto>>(_gamesService.GetAll()); 
            return Ok(games);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var game = _mapper.Map<GameGitDto>( _gamesService.GetById(id));

            if (game is null)
                return NotFound();

            return Ok(game);
        }


        [HttpGet("GetAllByCategoryId")]
        public IActionResult Get(int CategoryId)
        {
            var GamesByCategoryId = new GamesGitByCategoryIdDto();

            GamesByCategoryId.Games = _mapper.Map<IList<GameGitDto>>(_gamesService.GetAllByCategoryId(CategoryId));

            GamesByCategoryId.CategoryId = CategoryId;

            return Ok(GamesByCategoryId);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateGameFormDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var game = _mapper.Map<GameGitDto>(await _gamesService.Create(model));

            return Ok(game);
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