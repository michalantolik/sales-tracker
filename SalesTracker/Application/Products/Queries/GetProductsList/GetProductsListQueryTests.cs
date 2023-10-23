using Application.Interfaces;
using Domain.Products;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Products.Queries.GetProductsList
{
    [TestFixture]
    public class GetProductsListQueryTests
    {
        private GetProductsListQuery query;
        private AutoMocker mocker;
        private Product product;

        private const int Id = 1;
        private const string Name = "Product 1";

        [SetUp]
        public void SetUp()
        {
            this.mocker = new AutoMocker();

            this.product = new Product()
            {
                Id = Id,
                Name = Name
            };

            this.mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Products)
                .ReturnsDbSet(new List<Product> { this.product });

            query = mocker.CreateInstance<GetProductsListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfProducts()
        {
            var results = this.query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
