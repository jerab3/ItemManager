using Interfaces.Accessories;
using Interfaces.Location;
using Interfaces.DomainProperties;
using Interfaces.Vendor;

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
        public WarrantyItem(int id, string name, DateTime purchaseDate, decimal cost, IStorageLocation storageLocation, IVendor vendor, DateTime warrantyEndTime, List<IAccessory> accessories = null)
            : base(id, name, purchaseDate, cost, storageLocation, vendor, accessories)
        {
            this.WarrantyEndDate = warrantyEndTime;
        }
        /// <summary>
        /// Initializes a new instance of <see cref="WarrantyItem"/>  that we are currently using.
        /// </summary>
        public WarrantyItem(int id, string name, DateTime purchaseDate, decimal cost, string usageDescription, IVendor vendor, DateTime warrantyEndTime, List<IAccessory> accessories = null)
            : base(id, name, purchaseDate, cost, usageDescription, vendor, accessories)
        {
            this.WarrantyEndDate = warrantyEndTime;
        }

        public bool IsWarrantyStillValid()
        {
            return DateTime.Now <= WarrantyEndDate;
        }
    }
}