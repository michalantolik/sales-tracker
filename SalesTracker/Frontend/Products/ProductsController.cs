using Application.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Presentation.Products
{
    public class ProductsController : Controller
    {
        private readonly IGetProductsListQuery query;

        public ProductsController(IGetProductsListQuery query)
        {
            this.query = query;
        }

        public IActionResult Index()
        {
            var products = this.query.Execute();
            return View(products);
        }
    }
}
