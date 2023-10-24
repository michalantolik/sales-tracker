using Application.Interfaces;
using Application.Sales.Commands.CreateSale.Factory;
using Common.Dates;
using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Sales.Commands.CreateSale
{
    [TestFixture]
    public class CreateSaleCommandTests
    {
        private CreateSaleCommand command;
        private AutoMocker mocker;
        private CreateSaleModel model;
        private Sale sale;

        private static readonly DateTime Date = new(2001, 2, 3);
        private const int CustomerId = 1;
        private const int EmployeeId = 2;
        private const int ProductId = 3;
        private const decimal UnitPrice = 1.23m;
        private const int Quantity = 4;

        [SetUp]
        public void SetUp()
        {
            var customer = new Customer
            {
                Id = CustomerId
            };

            var employee = new Employee
            {
                Id = EmployeeId
            };

            var product = new Product
            {
                Id = ProductId,
                Price = UnitPrice
            };

            this.model = new CreateSaleModel()
            {
                CustomerId = CustomerId,
                EmployeeId = EmployeeId,
                ProductId = ProductId,
                Quantity = Quantity
            };

            this.sale = new Sale();

            this.mocker = new AutoMocker();

            this.mocker.GetMock<IDateService>()
                .Setup(p => p.GetDate())
                .Returns(Date);

            this.mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Customers)
                .ReturnsDbSet(new List<Customer> { customer });

            this.mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Employees)
                .ReturnsDbSet(new List<Employee> { employee });

            this.mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Products)
                .ReturnsDbSet(new List<Product> { product });

            this.mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Sales)
                .Returns(this.mocker.GetMock<DbSet<Sale>>().Object);

            this.mocker.GetMock<ISaleFactory>()
                .Setup(p => p.Create(
                    Date,
                    customer,
                    employee,
                    product,
                    Quantity))
                .Returns(this.sale);

            this.command = this.mocker.CreateInstance<CreateSaleCommand>();
        }

        [Test]
        public void TestExecuteShouldAddSaleToTheDatabase()
        {
            this.command.Execute(model);

            this.mocker.GetMock<DbSet<Sale>>()
                .Verify(p => p.Add(sale),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldSaveChangesToDatabase()
        {
            this.command.Execute(model);

            this.mocker.GetMock<IDatabaseService>()
                .Verify(p => p.Save(),
                    Times.Once);
        }

        [Test]
        public void TestExecuteShouldNotifyInventoryThatSaleOccurred()
        {
            this.command.Execute(this.model);

            this.mocker.GetMock<IInventoryService>()
                .Verify(p => p.NotifySaleOccurred(
                        ProductId,
                        Quantity),
                    Times.Once);
        }
    }
}
