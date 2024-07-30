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
        IEnumerable<IVendor> Vendors { get; }
        IEnumerable<IStorageLocation> StorageLocations { get; }
        IEnumerable<IItem> Items { get; }
        IEnumerable<IAccessory> Accessories { get; }

        void LoadData();
        void AddData(IIdentifiable identifiableObject);
        void RemoveData(IIdentifiable identifiableObject);
        void EditItem(IIdentifiable identifiableObject);
    }
}
