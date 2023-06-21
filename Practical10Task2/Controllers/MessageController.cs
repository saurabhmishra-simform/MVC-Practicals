using Microsoft.AspNetCore.Mvc;

namespace Practical10Task2.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MessageContentResult()
        {
            return Content("Message for content result");
        }
        public IActionResult MessageFileContentResult()
        {
            var myfile = System.IO.File.ReadAllBytes("C:\\Users\\saurabh\\Desktop\\Saurabh\\TestingFile.txt");
            return new FileContentResult(myfile, "application/txt");
        }
        public IActionResult MessageEmptyResult()
        {
            return new EmptyResult();
        }
        public IActionResult MessageJavaScriptResult()
        {
            string javascriptCode = "Message for javascript result";
            return Content(javascriptCode, "text/javascript");
        }
        public IActionResult MessageJsonResult()
        {
            return Json(new { Name = "John Smith", ID = 4, DateOfBirth = "12-12-1992" });
        }
    }
}
