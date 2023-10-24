using Application.Interfaces;
using Application.Sales.Commands.CreateSale.Factory;
using Common.Dates;

namespace Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : ICreateSaleCommand
    {
        private readonly IDateService dateService;
        private readonly IDatabaseService database;
        private readonly IInventoryService inventoryService;
        private readonly ISaleFactory factory;

        public CreateSaleCommand(
            IDateService dateService,
            IDatabaseService database,
            IInventoryService inventoryService,
            ISaleFactory factory)
        {
            this.dateService = dateService;
            this.database = database;
            this.inventoryService = inventoryService;
            this.factory = factory;
        }

        public void Execute(CreateSaleModel model)
        {
            var date = this.dateService.GetDate();

            var customer = this.database.Customers
                .Single(p => p.Id == model.CustomerId);

            var employee = this.database.Employees
                .Single(p => p.Id == model.EmployeeId);

            var product = this.database.Products
                .Single(p => p.Id == model.ProductId);

            var quantity = model.Quantity;

            var sale = factory.Create(
                date,
                customer,
                employee,
                product,
                quantity);

            this.database.Sales.Add(sale);

            this.database.Save();

            this.inventoryService.NotifySaleOccurred(product.Id, quantity);
        }
    }
}
