using Application.Interfaces;
using Infrastructure.Network;

namespace Infrastructure.Inventory
{
    /// <summary>
    /// Ficticious Inventory System ...
    /// ... which needs to be notified when a sale occurs.
    /// </summary>
    public class InventoryService : IInventoryService
    {
        // Note: these are hard coded to keep the demo simple
        private const string AddressTemplate = "http://abc123.com/inventory/products/{0}/notifysaleoccured/";
        private const string JsonTemplate = "{{\"quantity\": {0}}}";

        private readonly IHttpClientWrapper client;

        public InventoryService(IHttpClientWrapper client)
        {
            this.client = client;
        }

        public void NotifySaleOccurred(int productId, int quantity)
        {
            var address = string.Format(AddressTemplate, productId);

            var json = string.Format(JsonTemplate, quantity);

            this.client.Post(address, json);
        }
    }
}
