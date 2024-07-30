using Interfaces.Accessories;
using Interfaces.DataStorage;
using Interfaces.DomainProperties;
using Interfaces.Items;
using Interfaces.Location;
using Interfaces.Vendor;
using System.Security.Cryptography;

namespace DatabaseDataHanding
{
    public class DatabaseDataStorage : IDataStorage
    {
        public IEnumerable<IVendor> Vendors { get; private set; }
        public IEnumerable<IStorageLocation> StorageLocations { get; private set; }
        public IEnumerable<IItem> Items { get; private set; }
        public IEnumerable<IAccessory> Accessories { get; private set; }

        public void LoadData()
        {
            Console.WriteLine("Data loaded from database");

        }
        public void AddData(IIdentifiable identifiableObject)
        {
            if (identifiableObject == null)
            {
                throw new ArgumentNullException(nameof(identifiableObject), "Cannot be null.");
            }

            switch (identifiableObject)
            {
                case IVendor:
                    var vendors = this.Vendors.ToList();
                    vendors.Add(identifiableObject as IVendor);
                    this.Vendors = vendors;
                    break;

                case IStorageLocation:
                    var storageLocations = this.StorageLocations.ToList();
                    storageLocations.Add(identifiableObject as IStorageLocation);
                    this.StorageLocations = storageLocations;
                    break;

                case IItem:
                    var items = this.Items.ToList();
                    items.Add(identifiableObject as IItem);
                    this.Items = items;
                    break;

                case IAccessory:
                    var accessories = this.Accessories.ToList();
                    accessories.Add(identifiableObject as IAccessory);
                    this.Accessories = accessories;
                    break;
                default:
                    throw new ArgumentException(nameof(identifiableObject), "Is invalid.");
            }
            Console.WriteLine("Added data to database");
        }
        public void RemoveData(IIdentifiable identifiableObject)
        {
            Console.WriteLine("Removed data from database");
        }
        public void EditItem(IIdentifiable identifiableObject)
        {
            Console.WriteLine("Item was edited in database");
        }
        public void SaveData()
        {

        }
    }
}
