using Application.Sales.Commands.CreateSale;
using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using Microsoft.AspNetCore.Mvc;
using Presentation.Sales.Models;
using Presentation.Sales.Services;

namespace Presentation.Sales
{
    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly IGetSalesListQuery salesListQuery;
        private readonly IGetSaleDetailQuery saleDetailQuery;
        private readonly ICreateSaleViewModelFactory saleViewModelFactory;
        private readonly ICreateSaleCommand createSaleCommand;

        public SalesController(
            IGetSalesListQuery salesListQuery,
            IGetSaleDetailQuery saleDetailQuery,
            ICreateSaleViewModelFactory saleViewModelFactory,
            ICreateSaleCommand createSaleCommand)
        {
            this.salesListQuery = salesListQuery;
            this.saleDetailQuery = saleDetailQuery;
            this.saleViewModelFactory = saleViewModelFactory;
            this.createSaleCommand = createSaleCommand;
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

        [Route("create")]
        public ViewResult Create()
        {
            var viewModel = this.saleViewModelFactory.Create();
            return View(viewModel);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(CreateSaleViewModel viewModel)
        {
            this.createSaleCommand.Execute(viewModel.Sale);
            return RedirectToAction("index", "sales");
        }
    }
}
