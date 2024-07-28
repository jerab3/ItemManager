using Interfaces.Items;
using Interfaces.PurchaseLocations;
using Interfaces.Accessories;
using Interfaces.StorageLocations;

namespace Objects.Items
{
    public class Item : IItem
    {
        public int Id { get; }
        public string Name { get; set; }
        public DateTime PurchaseDate { get; }
        public IPurchaseLocation PurchaseLocation { get; }
        public decimal Cost { get; }
        public List<IAccessory>? Accessories { get; }
        public IStorageLocation? StorageLocation { get; set; }

        public Item(int id, string name, DateTime purchaseDate, IPurchaseLocation purchaseLocation, decimal cost, IStorageLocation? storageLocation = null, List<IAccessory>? accessories = null)
        {
            Id = id;
            Name = name;
            PurchaseDate = purchaseDate;
            PurchaseLocation = purchaseLocation;
            Cost = cost;
            StorageLocation = storageLocation;
            Accessories = accessories ?? new List<IAccessory>();
        }
    }

    public class WarrantyItem : Item, IWarrantyItem
    {
        public DateTime WarrantyEndDate { get; set; }

        public WarrantyItem(int id, string name, DateTime purchaseDate, IPurchaseLocation purchaseLocation, decimal cost, DateTime warrantyEndDate, IStorageLocation? storageLocation = null, List<IAccessory>? accessories = null)
            : base(id, name, purchaseDate, purchaseLocation, cost, storageLocation, accessories)
        {
            WarrantyEndDate = warrantyEndDate;
        }


        public bool IsWarrantyStillValid()
        {
            return DateTime.Now <= WarrantyEndDate;
        } 
    }
}