using Domains.AbstractDomains;
using Interfaces.Items;
using Interfaces.Vendor;

namespace Domains.Vendors
{
    /// <summary>
    /// <see cref="Eshop"/> represents an e-shop. For example: Amazon.
    /// </summary>
    public class Eshop : IdentifiableObject, IVendor
    {
        public IEnumerable<IItem> PurchasedItems { get; private set; }
        private string webAddress;
        public string WebAddress
        {
            get
            {
                return webAddress;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(WebAddress), "Cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(WebAddress), "Cannot be null, empty or contain only white spaces");
                }

                webAddress = value;
            }
        }

        public Eshop(string name, string webAddress, List<IItem> purchasedItems = null)
            :base(name)
        {
            this.WebAddress = webAddress;
            this.PurchasedItems = purchasedItems ?? Enumerable.Empty<IItem>();
        }

        public bool IsWebAddressValid()
        {
            return Uri.IsWellFormedUriString(WebAddress, UriKind.Absolute);
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
