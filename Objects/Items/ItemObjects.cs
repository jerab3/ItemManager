using Interfaces.Items;
using Interfaces.Accessories;
using Domains.ObjectProperties;
using Interfaces.Location;
using Interfaces.DomainProperties;

namespace Objects.Items
{
    /// <summary>
    /// <see cref="Item"/> represents an item bought without warranty.
    /// </summary>
    public class Item : UsableStoreableObject, IItem
    {
        public DateTime PurchaseDate { get; set; }
        public decimal Cost { get; set; }
        public List<IAccessory> Accessories { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="Item"/>  that is currently stored.
        /// </summary>
        public Item(int id, string name, DateTime purchaseDate, decimal cost, IStorageLocation storageLocation, List<IAccessory> accessories = null)
            :base(id, name, storageLocation)
        {

            this.PurchaseDate = purchaseDate;
            this.Cost = cost;
            this.Accessories = accessories ?? new List<IAccessory>();
        }
        /// <summary>
        /// Initializes a new instance of <see cref="Item"/>  that we are currently using.
        /// </summary>
        public Item(int id, string name, DateTime purchaseDate, decimal cost, string usageDescription, List<IAccessory> accessories = null)
            : base (id, name, usageDescription)
        {
            
            this.PurchaseDate = purchaseDate;
            this.Cost = cost;
            this.Accessories = accessories ?? new List<IAccessory>();
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
        public WarrantyItem(int id, string name, DateTime purchaseDate, decimal cost, IStorageLocation storageLocation, DateTime warrantyEndTime, List<IAccessory> accessories = null)
            :base(id, name, purchaseDate, cost, storageLocation, accessories)
        {
            this.WarrantyEndDate = warrantyEndTime;
        }
        /// <summary>
        /// Initializes a new instance of <see cref="WarrantyItem"/>  that we are currently using.
        /// </summary>
        public WarrantyItem(int id, string name, DateTime purchaseDate, decimal cost, string usageDescription, DateTime warrantyEndTime, List<IAccessory> accessories = null)
            : base(id, name, purchaseDate, cost, usageDescription, accessories)
        {
            this.WarrantyEndDate = warrantyEndTime;
        }

        public bool IsWarrantyStillValid()
        {
            return DateTime.Now <= WarrantyEndDate;
        } 
    }
}