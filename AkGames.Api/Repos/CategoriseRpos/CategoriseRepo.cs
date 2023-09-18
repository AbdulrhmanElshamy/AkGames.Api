using AkGames.Api.Core;
using AkGames.Api.Data;
using AkGames.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AkGames.Api.Repos.CategoriseRpos
{
    public class CategoriseRepo : ICategoriseRepo
    {
        private readonly AppDbContext _context;

        public CategoriseRepo(AppDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories
                .AsNoTracking()
                .ToList();
        }

        public Category? GetById(int id)
        {
            return _context.Categories
                .Include(g => g.Games)
                .AsNoTracking()
                .SingleOrDefault(g => g.Id == id);
        }

        public async Task Create(CategoryFormDto model)
        {

            Category category = new()
            {
                Name = model.Name,
            };

            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category?> Update(EditCategoryFormDto model)
        {
            var category = _context.Categories
                .SingleOrDefault(g => g.Id == model.Id);

            if (category is null)
                return null;

            category.Name = model.Name;

            var effectedRows = await  _context.SaveChangesAsync();

            if (effectedRows > 0)
            {
                return category;
            }
            else
            {

                return null;
            }
        }
    }
}
