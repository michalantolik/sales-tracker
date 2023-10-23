using Microsoft.AspNetCore.Mvc;

namespace Presentation.Sales
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
