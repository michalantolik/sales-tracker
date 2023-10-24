using Infrastructure.Network;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Infrastructure.Inventory
{
    [TestFixture]
    public class InventoryServiceTests
    {
        private InventoryService service;
        private AutoMocker mocker;

        private const string Address = "http://abc123.com/inventory/products/1/notifysaleoccured/";
        private const string Json = "{\"quantity\": 2}";

        [SetUp]
        public void SetUp()
        {
            this.mocker = new AutoMocker();

            this.service = this.mocker.CreateInstance<InventoryService>();
        }

        [Test]
        public void TestNotifySaleOccurredShouldNotifyInventorySystem()
        {
            this.service.NotifySaleOccurred(1, 2);

            this.mocker.GetMock<IHttpClientWrapper>()
                .Verify(p => p.Post(Address, Json),
                    Times.Once);
        }
    }
}
