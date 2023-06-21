using Microsoft.AspNetCore.Mvc;

namespace Practical17.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not found";
                    break;
            }
            return View("NotFound");
        }
    }
}
