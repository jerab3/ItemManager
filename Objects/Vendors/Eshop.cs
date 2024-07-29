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
        public List<IItem> PurchasedItems { get; set; }
        public string WebAddress { set; get; }

        public Eshop(int id, string name, string webAddress, List<IItem> purchasedItems = null)
            :base(id, name)
        {
            if (string.IsNullOrWhiteSpace(webAddress))
                throw new ArgumentException(nameof(webAddress), "Cannot be null, empty or contain only white spaces");

            this.WebAddress = webAddress;
            this.PurchasedItems = purchasedItems ?? new List<IItem>();
        }

        public bool IsWebAddressValid()
        {
            return Uri.IsWellFormedUriString(WebAddress, UriKind.Absolute);
        }
    }
}
