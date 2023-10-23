using Application.Interfaces;
using Domain.Employees;
using Moq.AutoMock;
using Moq.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Employees.Queries.GetEmployeesList
{
    [TestFixture]
    public class GetEmployeesListQueryTests
    {
        private GetEmployeesListQuery query;
        private AutoMocker mocker;
        private Employee employee;

        private const int Id = 1;
        private const string Name = "Employee 1";

        [SetUp]
        public void SetUp()
        {
            this.mocker = new AutoMocker();

            this.employee = new Employee()
            {
                Id = Id,
                Name = Name
            };

            this.mocker.GetMock<IDatabaseService>()
                .Setup(p => p.Employees)
                .ReturnsDbSet(new List<Employee> { this.employee });

            this.query = this.mocker.CreateInstance<GetEmployeesListQuery>();
        }

        [Test]
        public void TestExecuteShouldReturnListOfEmployees()
        {
            var results = this.query.Execute();

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.Name, Is.EqualTo(Name));
        }
    }
}
