namespace Application.Interfaces
{
    /// <summary>
    /// Interface to a ficticious Inventory System ...
    /// ... which needs to be notified when a sale occurs.
    /// </summary>
    public interface IInventoryService
    {
        void NotifySaleOccurred(int productId, int quantity);
    }
}
