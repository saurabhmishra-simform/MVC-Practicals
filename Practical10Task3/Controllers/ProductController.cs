using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
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
        [ResponseCache(Duration = 300)] //every 5 min
        public IActionResult Index()
        {
            var product = _context.Products.ToList();
            return View(product);
        }
       
        public String GetProductCount()
        {
            var productCount = _context.Products.Count().ToString();
            return "Product Count = " + productCount + " @ DateTime: " + DateTime.Now.ToString();
        }
    }
}
