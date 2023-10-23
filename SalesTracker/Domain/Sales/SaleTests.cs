using Domain.Customers;
using Domain.Employees;
using Domain.Products;
using NUnit.Framework;

namespace Domain.Sales
{
    /// <summary>
    /// Example unit tests to show where is their place in a domain-centric architecture.
    /// </summary>
    [TestFixture]
    public class SaleTests
    {
        private Sale sut;

        [SetUp]
        public void SetUp()
        {
            this.sut = new Sale();
        }

        [Test]
        public void TestSetAndGetId()
        {
            this.sut.Id = 1;
            Assert.That(this.sut.Id, Is.EqualTo(1));
        }

        [Test]
        public void TestSetAndGetDate()
        {
            this.sut.Date = new DateTime(2001, 2, 3); ;
            Assert.That(this.sut.Date, Is.EqualTo(new DateTime(2001, 2, 3)));
        }

        [Test]
        public void TestSetAndGetCustomer()
        {
            var customer = new Customer();
            this.sut.Customer = customer;
            Assert.That(this.sut.Customer, Is.EqualTo(customer));
        }

        [Test]
        public void TestSetAndGetEmployee()
        {
            var employee = new Employee();
            this.sut.Employee = employee;
            Assert.That(this.sut.Employee, Is.EqualTo(employee));
        }

        [Test]
        public void TestSetAndGetProduct()
        {
            var product = new Product();
            this.sut.Product = product;
            Assert.That(this.sut.Product, Is.EqualTo(product));
        }

        [Test]
        public void TestSetAndGetUnitPrice()
        {
            this.sut.UnitPrice = 1.00m;
            Assert.That(this.sut.UnitPrice, Is.EqualTo(1.00m));
        }

        [Test]
        public void TestSetAndGetQuantity()
        {
            this.sut.Quantity = 1;
            Assert.That(this.sut.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void TestSetUnitPriceShouldRecomputeTotalPrice()
        {
            this.sut.Quantity = 1;
            this.sut.UnitPrice = 1.23m;
            Assert.That(this.sut.TotalPrice, Is.EqualTo(1.23m));
        }

        [Test]
        public void TestSetQuantityShouldRecomputeTotalPrice()
        {
            this.sut.UnitPrice = 1.00m;
            this.sut.Quantity = 2;
            Assert.That(this.sut.TotalPrice, Is.EqualTo(2.00m));
        }
    }
}
