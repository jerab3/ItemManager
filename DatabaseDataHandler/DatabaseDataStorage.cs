using Interfaces.Accessories;
using Interfaces.DataStorage;
using Interfaces.DomainProperties;
using Interfaces.Items;
using Interfaces.Location;
using Interfaces.Vendor;

namespace DatabaseDataHanding
{
    public class DatabaseDataStorage : IDataStorage
    {
        public IEnumerable<IVendor> Vendors => throw new NotImplementedException();

        public IEnumerable<IStorageLocation> StorageLocations => throw new NotImplementedException();

        public IEnumerable<IItem> Items => throw new NotImplementedException();

        public IEnumerable<IAccessory> Accessories => throw new NotImplementedException();

        public void AddData(IIdentifiable identifiableObject)
        {
            throw new NotImplementedException();
        }

        public void EditItem(IIdentifiable identifiableObject)
        {
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            Console.WriteLine("Data loaded from database");
        }

        public void RemoveData(IIdentifiable identifiableObject)
        {
            throw new NotImplementedException();
        }
    }
}
