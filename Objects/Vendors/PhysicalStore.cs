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
        public IEnumerable<IItem> PurchasedItems { get; private set; }

        private string address;
        public string Address
        {
            get 
            {
                return address;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Address), "Cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(Address), "Cannot be null, empty or contain only white spaces");
                }

                address = value;
            }
        }
        private string city;
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(City), "Cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(City), "Cannot be null, empty or contain only white spaces");
                }

                city = value;
            }
        }

        public PhysicalStore(string name, string address, string city, List<IItem> purchasedItems = null)
            : base(name)
        {
            this.Address = address;
            this.City = city;
            this.PurchasedItems = purchasedItems ?? Enumerable.Empty<IItem>();
        }

        public void AddPurchasedItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Cannot be null");
            }
            var purchasedItems = this.PurchasedItems.ToList();
            purchasedItems.Add(item);
            this.PurchasedItems = purchasedItems;
        }

        public void RemovePurchasedItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Cannot be null");
            }
            var purchasedItems = this.PurchasedItems.ToList();
            purchasedItems.Remove(item);
            this.PurchasedItems = purchasedItems;
        }
    }
}
