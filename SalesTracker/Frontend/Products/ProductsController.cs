using Microsoft.AspNetCore.Mvc;

namespace Presentation.Products
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
