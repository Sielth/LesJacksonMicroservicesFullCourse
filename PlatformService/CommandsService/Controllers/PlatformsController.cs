using Microsoft.AspNetCore.Mvc;
using System;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {

        }

        [HttpPost]
        public ActionResult TestIndboundConnection()
        {
            Console.WriteLine("--> Indbound POST # Command Service");

            return Ok("Indbound test of from Platforms Controller");
        }
    }
}
