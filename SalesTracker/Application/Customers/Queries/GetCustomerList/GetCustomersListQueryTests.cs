using Application.Interfaces;
using Domain.Customers;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Customers.Queries.GetCustomerList
{
    [TestFixture]
    public class GetCustomersListQueryTests
    {
        private GetCustomersListQuery query;
        private AutoMocker mocker;
        private Customer customer;

        private const int Id = 1;
        private const string Name = "Customer 1";

        [SetUp]
        public void SetUp()
        {
            this.mocker = new AutoMocker();
            this.customer = new Customer()
            {
                Id = Id,
                Name = Name
            };

            mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Customers)
                .ReturnsDbSet(new List<Customer> { customer });

            query = mocker.CreateInstance<GetCustomersListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfCustomers()
        {
            var results = query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
