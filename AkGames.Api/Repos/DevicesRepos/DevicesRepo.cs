using AkGames.Api.Core;
using AkGames.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace AkGames.Api.Repos.DevicesRepos
{
    public class DevicesRepo : IDevicesRepo
    {
        private readonly AppDbContext _context;

        public DevicesRepo(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Device> GetAll()
        {
            return _context.Devices
                .AsNoTracking()
                .ToList();
        }
    }
}
