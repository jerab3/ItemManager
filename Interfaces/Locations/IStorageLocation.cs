using Interfaces.DomainProperties;

namespace Interfaces.Location
{
    /// <summary>
    /// Defines interface for classes that serve as storage.
    /// </summary>
    public interface IStorageLocation: IIdentifiable
    {
        List<IStorable> StoredObjects { get; }
    }
}
