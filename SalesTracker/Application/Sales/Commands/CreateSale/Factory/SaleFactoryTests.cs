using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using NUnit.Framework;

namespace Application.Sales.Commands.CreateSale.Factory
{
    [TestFixture]
    public class SaleFactoryTests
    {
        private SaleFactory factory;
        private Customer customer;
        private Employee employee;
        private Product product;

        private static readonly DateTime DateTime = new DateTime(2001, 2, 3);
        private const int Quantity = 123;
        private const decimal Price = 1.00m;

        [SetUp]
        public void SetUp()
        {
            this.customer = new Customer();

            this.employee = new Employee();

            this.product = new Product
            {
                Price = Price
            };

            this.factory = new SaleFactory();
        }

        [Test]
        public void TestCreateShouldCreateSale()
        {
            var result = this.factory.Create(DateTime, this.customer, this.employee, this.product, Quantity);

            Assert.That(result.Date, Is.EqualTo(DateTime));
            Assert.That(result.Customer, Is.EqualTo(this.customer));
            Assert.That(result.Employee, Is.EqualTo(this.employee));
            Assert.That(result.Product, Is.EqualTo(this.product));
            Assert.That(result.UnitPrice, Is.EqualTo(Price));
            Assert.That(result.Quantity, Is.EqualTo(Quantity));
        }

    }
}
