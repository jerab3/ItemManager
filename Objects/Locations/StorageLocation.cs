using Domains.AbstractDomains;
using Interfaces.DomainProperties;
using Interfaces.Location;

namespace Domains.Locations
{
    /// <summary>
    /// <see cref="StorageLocation"/> represents rooms or objects, which refer to storage locations. For example: basement.
    /// </summary>
    public class StorageLocation : IdentifiableObject, IStorageLocation
    {
        public List<IStorable> StoredObjects { get; set; }

        public StorageLocation(int id, string name, List<IStorable> storedObjects = null)
            : base(id, name)
        {
            this.StoredObjects = storedObjects ?? new List<IStorable>();
        }
    }
}
