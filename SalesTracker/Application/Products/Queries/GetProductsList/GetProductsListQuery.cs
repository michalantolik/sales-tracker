using Application.Interfaces;

namespace Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IGetProductsListQuery
    {
        private readonly IDatabaseService database;

        public GetProductsListQuery(IDatabaseService database)
        {
            this.database = database;
        }

        public List<ProductModel> Execute()
        {
            var products = this.database.Products
                .Select(p => new ProductModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    UnitPrice = p.Price
                });

            return products.ToList();
        }
    }
}
