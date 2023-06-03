using Microsoft.AspNetCore.Mvc;

namespace Practical9Task2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
