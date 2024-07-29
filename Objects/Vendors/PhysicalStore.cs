using Domains.AbstractDomains;
using Interfaces.Items;
using Interfaces.Vendor;

namespace Domains.Vendors
{
    /// <summary>
    /// <see cref="PhysicalStore"/> represents a physical store. For example: Wallmart.
    /// </summary>
    public class PhysicalStore : IdentifiableObject, IVendor
    {
        public List<IItem> PurchasedItems { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public PhysicalStore(int id, string name, string address, string city, List<IItem> purchasedItems = null)
            : base(id, name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(nameof(address), "Cannot be null, empty or contain only white spaces");

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException(nameof(city), "Cannot be null, empty or contain only white spaces");

            this.Address = address;
            this.City = city;
            this.PurchasedItems = purchasedItems ?? new List<IItem>();
        }
    }
}
