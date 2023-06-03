using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Practical10Task3.Attributes;
using Practical10Task3.Models;

namespace Practical10Task3.Controllers
{
    public class ProductController : Controller
    {
        public readonly SqlpracticalContext _context;
        public ProductController(SqlpracticalContext context)
        {
            _context = context;
        }
        [ResponseCache(Duration = 300)] // Cache for 5 minutes (300 seconds)
        public IActionResult Index()
        {
            var product = _context.Products.ToList();
            return View(product);
        }

        [HttpGet]
        [PartialCache(300,"5MinutesCache")] // Cache for 5 minutes (300 seconds)
        public IActionResult GetProductCount()
        {
            var productCount = _context.Products.Count().ToString();
            var result = "Product Count = " + productCount + " @ DateTime: " + DateTime.Now.ToString();
            return Content(result);
        }
    }
}
