using AkGames.Api.Repos.CategoriseRpos;
using AkGames.Api.Repos.DevicesRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkGames.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
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
