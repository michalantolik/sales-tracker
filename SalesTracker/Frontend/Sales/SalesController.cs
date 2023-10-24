using Application.Sales.Queries.GetSalesList;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Sales
{
    public class SalesController : Controller
    {
        private readonly IGetSalesListQuery query;

        public SalesController(IGetSalesListQuery query)
        {
            this.query = query;
        }

        public IActionResult Index()
        {
            var sales = this.query.Execute();
            return View(sales);
        }
    }
}
