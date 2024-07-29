using Interfaces.DomainProperties;
using Interfaces.Items;

namespace Interfaces.Vendor
{
    /// <summary>
    /// Defines interface for classes that serve as vendors
    /// </summary>
    public interface IVendor : IIdentifiable
    {
        List<IItem> PurchasedItems { get; set; }
    }
}
