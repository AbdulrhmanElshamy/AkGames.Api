using AkGames.Api.Repos.CategoriseRpos;
using AkGames.Api.Repos.DevicesRepos;
using Microsoft.AspNetCore.Mvc;

namespace AkGames.Api.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDevicesRepo _devicesRepo;

        public DevicesController(IDevicesRepo devicesRepo)
        {
            _devicesRepo = devicesRepo;
        }


        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var devices = _devicesRepo.GetAll();
            return Ok(devices);
        }
    }
}
