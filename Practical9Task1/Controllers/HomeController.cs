using Microsoft.AspNetCore.Mvc;

namespace Practical9Task1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello World");
        }
    }
}
