using Interfaces.Items;
using Interfaces.Accessories;
using Domains.ObjectProperties;
using Interfaces.Location;

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

}