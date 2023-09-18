using AkGames.Api.Core;

namespace AkGames.Api.Repos.DevicesRepos
{
    public interface IDevicesRepo
    {
        IEnumerable<Device> GetAll();
    }
}
