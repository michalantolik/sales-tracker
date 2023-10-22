using Microsoft.AspNetCore.Mvc;

namespace Frontend.Sales
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
