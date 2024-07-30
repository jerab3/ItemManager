using Interfaces.DomainProperties;
using Interfaces.Items;

namespace Interfaces.Vendor
{
    /// <summary>
    /// Defines interface for classes that serve as vendors.
    /// </summary>
    public interface IVendor : IIdentifiable
    {
        IEnumerable<IItem> PurchasedItems { get; }
 
        void AddPurchasedItem();
        void RemovePurchasedItem();
    }
}
