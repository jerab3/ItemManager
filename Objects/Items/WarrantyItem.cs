using Interfaces.Accessories;
using Interfaces.Location;
using Interfaces.DomainProperties;

namespace Objects.Items
{

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
            : base(id, name, purchaseDate, cost, storageLocation, accessories)
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