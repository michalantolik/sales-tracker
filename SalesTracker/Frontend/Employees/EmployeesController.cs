using Microsoft.AspNetCore.Mvc;

namespace Presentation.Employees
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
