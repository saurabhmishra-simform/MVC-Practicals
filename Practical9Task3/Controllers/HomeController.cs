using Microsoft.AspNetCore.Mvc;

namespace Practical9Task3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello World");
        }
    }
}
