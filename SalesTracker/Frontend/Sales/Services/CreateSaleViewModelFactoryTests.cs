using Application.Customers.Queries.GetCustomerList;
using Application.Employees.Queries.GetEmployeesList;
using Application.Products.Queries.GetProductsList;
using Moq.AutoMock;
using NUnit.Framework;

namespace Presentation.Sales.Services
{
    [TestFixture]
    public class CreateSaleViewModelFactoryTests
    {
        private CreateSaleViewModelFactory factory;
        private AutoMocker mocker;

        private const int CustomerId = 1;
        private const string CustomerName = "Customer 1";
        private const int EmployeeId = 2;
        private const string EmployeeName = "Employee 2";
        private const int ProductId = 3;
        private const string ProductName = "Product 3";
        private const decimal ProductPrice = 1.23m;

        [SetUp]
        public void SetUp()
        {
            mocker = new AutoMocker();

            var customer = new CustomerModel
            {
                Id = CustomerId,
                Name = CustomerName,
            };

            var employee = new EmployeeModel()
            {
                Id = EmployeeId,
                Name = EmployeeName
            };

            var product = new ProductModel
            {
                Id = ProductId,
                Name = ProductName,
                UnitPrice = ProductPrice
            };

            mocker.GetMock<IGetCustomersListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<CustomerModel> { customer });

            mocker.GetMock<IGetEmployeesListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<EmployeeModel> { employee });

            mocker.GetMock<IGetProductsListQuery>()
                .Setup(p => p.Execute())
                .Returns(new List<ProductModel> { product });

            factory = mocker.CreateInstance<CreateSaleViewModelFactory>();
        }

        [Test]
        public void TestCreateShouldSetCustomers()
        {
            var viewModel = factory.Create();

            var result = viewModel.Customers.Single();

            Assert.That(result.Value,
                Is.EqualTo(CustomerId.ToString()));

            Assert.That(result.Text,
                Is.EqualTo(CustomerName));
        }

        [Test]
        public void TestCreateShouldSetEmployees()
        {
            var viewModel = factory.Create();

            var result = viewModel.Employees.Single();

            Assert.That(result.Value,
                Is.EqualTo(EmployeeId.ToString()));

            Assert.That(result.Text,
                Is.EqualTo(EmployeeName));
        }

        [Test]
        public void TestCreateShouldSetProducts()
        {
            var viewModel = factory.Create();

            var result = viewModel.Products.Single();

            Assert.That(result.Value,
                Is.EqualTo(ProductId.ToString()));

            Assert.That(result.Text,
                Is.EqualTo("Product 3 ($1.23)"));
        }

        [Test]
        public void TestCreateShouldCreateEmptySaleModel()
        {
            var viewModel = factory.Create();

            var result = viewModel.Sale;

            Assert.That(result, Is.Not.Null);
        }
    }
}
