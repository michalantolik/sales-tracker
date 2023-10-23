﻿using NUnit.Framework;

namespace Domain.Customers
{
    /// <summary>
    /// Example unit tests to show where is their place in a domain-centric architecture.
    /// </summary>
    [TestFixture]
    public class CustomerTests
    {
        private Customer sut;

        [SetUp]
        public void SetUp()
        {
            this.sut = new Customer();
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
