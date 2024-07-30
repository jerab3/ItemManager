using Interfaces.Items;
using Interfaces.Accessories;
using Domains.ObjectProperties;
using Interfaces.Location;
using Interfaces.Vendor;

namespace Objects.Items
{
    /// <summary>
    /// <see cref="Item"/> represents an item bought without warranty.
    /// </summary>
    public class Item : UsableStoreableObject, IItem
    {
        public DateTime PurchaseDate { get; set; }
        public decimal Cost { get; set; }

        private IVendor vendor;
        public IVendor Vendor
        {
            get
            {
                return vendor;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Vendor), "Cannot be null");
                }
                vendor = value;
            }
        }
        public IEnumerable<IAccessory> Accessories { get; private set; }

        /// <summary>
        /// Initializes a new instance of <see cref="Item"/>  that is currently stored.
        /// </summary>
        public Item(string name, DateTime purchaseDate, decimal cost, IStorageLocation storageLocation, IVendor vendor, List<IAccessory> accessories = null)
            :base(name, storageLocation)
        {

            this.PurchaseDate = purchaseDate;
            this.Cost = cost;
            this.Accessories = accessories ?? Enumerable.Empty<IAccessory>();
            this.Vendor = vendor;
            vendor.AddPurchasedItem(this);
        }
        /// <summary>
        /// Initializes a new instance of <see cref="Item"/>  that we are currently using.
        /// </summary>
        public Item(string name, DateTime purchaseDate, decimal cost, string usageDescription, IVendor vendor, List<IAccessory> accessories = null)
            : base (name, usageDescription)
        {
            
            this.PurchaseDate = purchaseDate;
            this.Cost = cost;
            this.Accessories = accessories ?? Enumerable.Empty<IAccessory>();
            this.Vendor = vendor;
            vendor.AddPurchasedItem(this);
        }

        public void AddAccessory(IAccessory accessory)
        {
            if (accessory == null)
            {
                throw new ArgumentNullException(nameof(accessory), "Cannot be null");
            }
            var accessories = this.Accessories.ToList();
            accessories.Add(accessory);
            this.Accessories = accessories;
        }

        public void RemoveAccessory(IAccessory accessory)
        {
            if (accessory == null)
            {
                throw new ArgumentNullException(nameof(accessory), "Cannot be null");
            }
            var accessories = this.Accessories.ToList();
            accessories.Remove(accessory);
            this.Accessories = accessories;
        }
    }

}