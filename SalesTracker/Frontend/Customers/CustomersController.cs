using Application.Customers.Queries.GetCustomerList;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Customers
{
    public class CustomersController : Controller
    {
        private readonly IGetCustomersListQuery query;

        public CustomersController(IGetCustomersListQuery query)
        {
            this.query = query;
        }

        public IActionResult Index()
        {
            var customers = query.Execute();
            return View(customers);
        }
    }
}
