using Interfaces.Accessories;
using Interfaces.DomainProperties;
using Interfaces.Items;
using Interfaces.Location;
using Interfaces.Vendor;

namespace Interfaces.DataStorage
{
    /// <summary>
    /// Defines an interface for classes that handle data storage.
    /// </summary>
    public interface IDataStorage
    {
        public List<IVendor> Vendors { get; }
        public List<IStorageLocation> StorageLocations { get; }
        public List<IItem> Items { get; }
        public List<IAccessory> Accessories { get; }

        public void LoadData();
        public void AddData(IIdentifiable identifiableObject);
        public void RemoveData(int id);
    }
}
