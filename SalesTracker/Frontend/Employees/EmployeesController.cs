using Application.Employees.Queries.GetEmployeesList;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Employees
{
    [Route("employees")]
    public class EmployeesController : Controller
    {
        private readonly IGetEmployeesListQuery query;

        public EmployeesController(IGetEmployeesListQuery query)
        {
            this.query = query;
        }

        [Route("")]
        public IActionResult Index()
        {
            var employees = this.query.Execute();
            return View(employees);
        }
    }
}
