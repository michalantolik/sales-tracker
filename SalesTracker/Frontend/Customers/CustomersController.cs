using Microsoft.AspNetCore.Mvc;

namespace Presentation.Customers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
