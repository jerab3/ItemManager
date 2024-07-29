using Interfaces.Location;

namespace Interfaces.DomainProperties
{
    /// <summary>
    /// Defines the properties and methods for classes that can be associated with a storage location.
    /// </summary>
    public interface IStorable
    {
        IStorageLocation StorageLocation { get; }
        public void SetStorageLocation(IStorageLocation storageLocation);
    }
}
