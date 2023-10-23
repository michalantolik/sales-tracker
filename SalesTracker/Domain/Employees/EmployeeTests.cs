using NUnit.Framework;

namespace Domain.Employees
{
    /// <summary>
    /// Example unit tests to show where is their place in a domain-centric architecture.
    /// </summary>
    [TestFixture]
    public class EmployeeTests
    {
        private Employee sut;

        [SetUp]
        public void SetUp()
        {
            this.sut = new Employee();
        }

        [Test]
        public void TestSetAndGetId()
        {
            this.sut.Id = 1;
            Assert.That(this.sut.Id, Is.EqualTo(1));
        }

        [Test]
        public void TestSetAndGetName()
        {
            this.sut.Name = "Test";
            Assert.That(this.sut.Name, Is.EqualTo("Test"));
        }
    }
}
