using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Practical10Task1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index(string name)
        {
           return Content("Employee name: " + name); 
        }
    }
}
