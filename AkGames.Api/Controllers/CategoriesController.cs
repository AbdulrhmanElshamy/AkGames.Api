using AkGames.Api.Dtos;
using AkGames.Api.Repos.CategoriseRpos;
using Microsoft.AspNetCore.Mvc;

namespace AkGames.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriseRepo _categoriseRepo;

        public CategoriesController(ICategoriseRepo categoriseRepo)
        {
            _categoriseRepo = categoriseRepo;
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var categories = _categoriseRepo.GetAll();
            return Ok(categories);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var category = _categoriseRepo.GetById(id);

            if (category is null)
                return NotFound();

            return Ok(category);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryFormDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _categoriseRepo.Create(model);

            return Ok(model);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(EditCategoryFormDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var game = await _categoriseRepo.Update(model);

            if (game is null)
                return BadRequest();

            return NoContent();
        }
    }
}
