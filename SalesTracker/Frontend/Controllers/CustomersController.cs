using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
