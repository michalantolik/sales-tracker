using Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Products
{
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IGetProductsListQuery query;

        public ProductsController(IGetProductsListQuery query)
        {
            this.query = query;
        }

        [Route("")]
        public IActionResult Index()
        {
            var products = this.query.Execute();
            return View(products);
        }
    }
}
