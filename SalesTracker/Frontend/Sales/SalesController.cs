using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Sales
{
    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly IGetSalesListQuery salesListQuery;
        private readonly IGetSaleDetailQuery saleDetailQuery;

        public SalesController(
            IGetSalesListQuery salesListQuery,
            IGetSaleDetailQuery saleDetailQuery)
        {
            this.salesListQuery = salesListQuery;
            this.saleDetailQuery = saleDetailQuery;
        }

        [Route("")]
        public IActionResult Index()
        {
            var sales = this.salesListQuery.Execute();
            return View(sales);
        }

        [Route("{id:int}")]
        public ViewResult Detail(int id)
        {
            var sale = this.saleDetailQuery.Execute(id);
            return View(sale);
        }
    }
}
