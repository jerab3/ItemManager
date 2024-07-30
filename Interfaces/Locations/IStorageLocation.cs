using Interfaces.DomainProperties;

namespace Interfaces.Location
{
    /// <summary>
    /// Defines interface for classes that serve as storage.
    /// </summary>
    public interface IStorageLocation: IIdentifiable
    {
        IEnumerable<IStorable> StoredObjects { get; }

        void AddStoredObject();
        void RemoveStoredObject();
    }
}
