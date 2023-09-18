using AkGames.Api.Core;
using AkGames.Api.Dtos;

namespace AkGames.Api.Repos.GamesRepos
{
    public interface IGamesRepo
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateGameFormDto model);
        Task<Game?> Update(EditGameFormDto model);
        bool Delete(int id);
    }
}
