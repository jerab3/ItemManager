using Interfaces.Items;
using Interfaces.PurchaseLocations;
using Interfaces.Accessories;
using Interfaces.StorageLocations;
using Objects.StorageLocations;
using Interfaces.ObjectProperties;
using Objects.ObjectProperties;

namespace Objects.Items
{
    /// <summary>
    /// <see cref="Item"/> represents an item bought without warranty.
    /// </summary>
    public class Item : UsableStoreable, IItem
    {
        public int Id { get; }
        public string ItemName { get; set; }
        public DateTime PurchaseDate { get; }
        public IPurchaseLocation PurchaseLocation { get; }
        public decimal Cost { get; }
        public List<IAccessory>? Accessories { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Item"/>  that is currently stored.
        /// </summary>
        public Item(int id, string name, DateTime purchaseDate, IPurchaseLocation purchaseLocation, decimal cost, List<IAccessory>? accessories, IStorageLocation storageLocation)
            :base(storageLocation)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name), "Cannot be null, empty or contain only white spaces");
            }
            if (purchaseLocation == null)
            {
                throw new ArgumentNullException(nameof(purchaseLocation), "Cannot be null");
            }

            this.Id = id;
            this.ItemName = name;
            this.PurchaseDate = purchaseDate;
            this.PurchaseLocation = purchaseLocation;
            this.Cost = cost;
            this.Accessories = accessories;
        }
        /// <summary>
        /// Initializes a new instance of <see cref="Item"/>  that we are currently using.
        /// </summary>
        public Item(int id, string name, DateTime purchaseDate, IPurchaseLocation purchaseLocation, decimal cost, List<IAccessory>? accessories, string usageDescription)
            : base (usageDescription)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name), "Cannot be null, empty or contain only white spaces");
            }
            if (purchaseLocation == null)
            {
                throw new ArgumentNullException(nameof(purchaseLocation), "Cannot be null");
            }

            this.Id = id;
            this.ItemName = name;
            this.PurchaseDate = purchaseDate;
            this.PurchaseLocation = purchaseLocation;
            this.Cost = cost;
            this.Accessories = accessories;
        }
    }

    /// <summary>
    /// <see cref="WarrantyItem"/> represents an item bought with warranty.
    /// </summary>
    public class WarrantyItem : Item, IHasWarranty
    {
        public DateTime WarrantyEndDate { get; set; }
        /// <summary>
        /// Initializes a new instance of <see cref="WarrantyItem"/>  that is currently stored.
        /// </summary>
        public WarrantyItem(int id, string name, DateTime purchaseDate, IPurchaseLocation purchaseLocation, decimal cost, List<IAccessory>? accessories, IStorageLocation storageLocation, DateTime warrantyEndTime)
            :base(id, name, purchaseDate, purchaseLocation, cost, accessories, storageLocation)
        {
            this.WarrantyEndDate = warrantyEndTime;
        }
        /// <summary>
        /// Initializes a new instance of <see cref="WarrantyItem"/>  that we are currently using.
        /// </summary>
        public WarrantyItem(int id, string name, DateTime purchaseDate, IPurchaseLocation purchaseLocation, decimal cost, List<IAccessory>? accessories, string usageDescription, DateTime warrantyEndTime)
            : base(id, name, purchaseDate, purchaseLocation, cost, accessories, usageDescription)
        {
            this.WarrantyEndDate = warrantyEndTime;
        }

        public bool IsWarrantyStillValid()
        {
            return DateTime.Now <= WarrantyEndDate;
        } 
    }
}