using Newtonsoft.Json;
using Interfaces.Accessories;
using Interfaces.DataStorage;
using Interfaces.DomainProperties;
using Interfaces.Items;
using Interfaces.Location;
using Interfaces.Vendor;
using Domains.Vendors;
using Domains.Locations;
using Objects.Items;
using Domains.Accessories;
using Newtonsoft.Json.Serialization;

namespace FileDataHanding
{
    public class FileDataStorage : IDataStorage
    {
        private const string filePath = "data.json";

        public IEnumerable<IVendor> Vendors { get; private set; }
        public IEnumerable<IStorageLocation> StorageLocations { get; private set; }
        public IEnumerable<IItem> Items { get; private set; }
        public IEnumerable<IAccessory> Accessories { get; private set; }

        public void LoadData()
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);


                var data = JsonConvert.DeserializeObject<FileData>(jsonData);

                if (data == null)
                {
                    InicializeCollections();
                    return;
                }

                this.Vendors = Enumerable.Empty<IVendor>();
                this.StorageLocations = (data.StorageLocations?.Cast<IStorageLocation>() ?? Enumerable.Empty<IStorageLocation>());
                this.Items = Enumerable.Empty<IItem>();
                this.Accessories = Enumerable.Empty<IAccessory>();
            }
            else
            {
                InicializeCollections();
                File.Create(filePath);
            }

        }
        private void InicializeCollections()
        {
            this.Vendors = Enumerable.Empty<IVendor>();
            this.StorageLocations = Enumerable.Empty<IStorageLocation>();
            this.Items = Enumerable.Empty<IItem>();
            this.Accessories = Enumerable.Empty<IAccessory>();
        }

        public void AddData(IIdentifiable identifiableObject)
        {
            if (identifiableObject == null)
            {
                throw new ArgumentNullException(nameof(identifiableObject), "Cannot be null.");
            }

            switch (identifiableObject)
            {
                case IStorageLocation:
                    var storageLocations = this.StorageLocations.ToList();
                    storageLocations.Add(identifiableObject as IStorageLocation);
                    this.StorageLocations = storageLocations;
                    break;
                default:
                    throw new ArgumentException(nameof(identifiableObject), "Is invalid.");
            }
            SaveData();
        }
        public void RemoveData(IIdentifiable identifiableObject)
        {
            Console.WriteLine("Removed data from file");
        }
        public void EditItem(IIdentifiable identifiableObject)
        {
            throw new NotImplementedException();
        }
        public void SaveData()
        {
            var data = new FileData
            {
                Eshops = this.Vendors.OfType<Eshop>(),
                PhysicalStores = this.Vendors.OfType<PhysicalStore>(),
                StorageLocations = this.StorageLocations.OfType<StorageLocation>(),
                Items = this.Items.OfType<Item>(),
                WarrantyItems = this.Items.OfType<WarrantyItem>(),
                StorableAccessories = this.Accessories.OfType<StorableAccessory>(),
                UsableStoreableAccessories = this.Accessories.OfType<UsableStoreableAccessory>()
            };

            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }
    }

    internal class FileData
    {
        public IEnumerable<Eshop> Eshops { get; set; }
        public IEnumerable<PhysicalStore> PhysicalStores { get; set; }
        public IEnumerable<StorageLocation> StorageLocations { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<WarrantyItem> WarrantyItems { get; set; }
        public IEnumerable<StorableAccessory> StorableAccessories { get; set; }
        public IEnumerable<UsableStoreableAccessory> UsableStoreableAccessories{ get; set; }
    }
}
