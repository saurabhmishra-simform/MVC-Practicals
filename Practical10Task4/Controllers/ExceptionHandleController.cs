using Microsoft.AspNetCore.Mvc;
using Practical10Task4.Filters;

namespace Practical10Task4.Controllers
{
    public class ExceptionHandleController : Controller
    {
        [CustomException]
        public IActionResult Index()
        {
            throw new DivideByZeroException("Divide by zero");
        }
    }
}
