using Interfaces.Accessories;
using Interfaces.DataStorage;
using Interfaces.DomainProperties;
using Interfaces.Items;
using Interfaces.Location;
using Interfaces.Vendor;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;

namespace DatabaseDataHanding
{
    public class DatabaseDataStorage : IDataStorage
    {
        private readonly ApplicationDatabaseContext _context;

        public IEnumerable<IVendor> Vendors { get; private set; }
        public IEnumerable<IStorageLocation> StorageLocations { get; private set; }
        public IEnumerable<IItem> Items { get; private set; }
        public IEnumerable<IAccessory> Accessories { get; private set; }

        public DatabaseDataStorage()
        {
            _context = new ApplicationDatabaseContext();
        }
        public void LoadData()
        {
            try
            {
            this.Vendors = _context.Eshops.Cast<IVendor>().ToList()
                .Concat(_context.PhysicalStores.Cast<IVendor>().ToList());

            this.StorageLocations = _context.StorageLocations.ToList();
            this.Accessories = _context.StorableAccessories.Cast<IAccessory>().ToList()
                .Concat(_context.UsableStoreableAccessories.Cast<IAccessory>().ToList());

            this.Items = _context.Items.Cast<IItem>().ToList()
                .Concat(_context.WarrantyItems.Cast<IItem>().ToList());
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("One or more tables do not exist in the database.", e);
            }

            Console.WriteLine("Data loaded from database");

        }
        public void AddData(IIdentifiable identifiableObject)
        {
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
