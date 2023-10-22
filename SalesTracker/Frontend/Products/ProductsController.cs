using Microsoft.AspNetCore.Mvc;

namespace Frontend.Products
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
