using AkGames.Api.Dtos;
using AkGames.Api.Repos.CategoriseRpos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AkGames.Api.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriseRepo _categoriseRepo;

        private readonly IMapper _mapper;

        public CategoriesController(ICategoriseRepo categoriseRepo, IMapper mapper)
        {
            _categoriseRepo = categoriseRepo;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var categories = _mapper.Map<IList<CategoryGitDto>>(_categoriseRepo.GetAll());
            return Ok(categories);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var category = _mapper.Map <CategoryGitDto>(_categoriseRepo.GetById(id));

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

             var category = _mapper.Map<CategoryGitDto>(await _categoriseRepo.Create(model));

            return Ok(category);
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
