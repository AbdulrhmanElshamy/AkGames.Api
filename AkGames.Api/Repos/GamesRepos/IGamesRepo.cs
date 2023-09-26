using AkGames.Api.Core.Models;
using AkGames.Api.Dtos;

namespace AkGames.Api.Repos.GamesRepos
{
    public interface IGamesRepo
    {
        IEnumerable<Game> GetAll();
        IEnumerable<Game> GetAllByCategoryId(int Id);
        Game? GetById(int id);
        Task<Game> Create(CreateGameFormDto model);
        Task<Game?> Update(EditGameFormDto model);
        bool Delete(int id);
    }
}
