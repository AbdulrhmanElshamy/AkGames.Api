using AkGames.Api.Core;
using AkGames.Api.Dtos;

namespace AkGames.Api.Repos.CategoriseRpos
{
    public interface ICategoriseRepo
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
        Task Create(CategoryFormDto model);
        Task<Category?> Update(EditCategoryFormDto model);
    }
}
