using AkGames.Api.Core.Models;

namespace AkGames.Api.Repos.DevicesRepos
{
    public interface IDevicesRepo
    {
        IEnumerable<Device> GetAll();
    }
}
