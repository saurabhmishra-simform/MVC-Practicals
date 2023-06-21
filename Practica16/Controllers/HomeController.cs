using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practica16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult SimpleMessage()
        {
            _logger.LogInformation("Log message in the SimpleMessage() method");

            return Content("Hello World");
        }
    }
}
