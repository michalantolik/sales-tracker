using Microsoft.AspNetCore.Mvc;

namespace Frontend.Employees
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
