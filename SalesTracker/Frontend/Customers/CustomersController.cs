using Microsoft.AspNetCore.Mvc;

namespace Frontend.Customers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
