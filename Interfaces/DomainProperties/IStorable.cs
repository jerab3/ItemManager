using Interfaces.Location;

namespace Interfaces.DomainProperties
{
    /// <summary>
    /// Defines the properties and methods for classes that can be stored in a <see cref="IStorageLocation"/>
    /// </summary>
    public interface IStorable
    {
        IStorageLocation StorageLocation { get; set; }
    }
}
