using Application.Interfaces;

namespace Application.Sales.Queries.GetSalesList
{
    public class GetSalesListQuery : IGetSalesListQuery
    {
        private readonly IDatabaseService database;

        public GetSalesListQuery(IDatabaseService database)
        {
            this.database = database;
        }

        public List<SalesListItemModel> Execute()
        {
            var sales = this.database.Sales
                .Select(p => new SalesListItemModel()
                {
                    Id = p.Id,
                    Date = p.Date,
                    CustomerName = p.Customer.Name,
                    EmployeeName = p.Employee.Name,
                    ProductName = p.Product.Name,
                    UnitPrice = p.UnitPrice,
                    Quantity = p.Quantity,
                    TotalPrice = p.TotalPrice
                });

            return sales.ToList();
        }
    }
}
