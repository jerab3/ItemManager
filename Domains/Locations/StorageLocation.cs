using Domains.AbstractDomains;
using Interfaces.Accessories;
using Interfaces.DomainProperties;
using Interfaces.Location;

namespace Domains.Locations
{
    /// <summary>
    /// <see cref="StorageLocation"/> represents rooms or objects, which refer to storage locations. For example: basement.
    /// </summary>
    public class StorageLocation : IdentifiableObject, IStorageLocation
    {
        public IEnumerable<IStorable> StoredObjects { get; private set; }

        public StorageLocation(string name, List<IStorable> storedObjects = null)
            : base(name)
        {
            this.StoredObjects = storedObjects ?? Enumerable.Empty<IStorable>();
        }

        public void AddStoredObject(IStorable storableObject)
        {
            if (storableObject == null)
            {
                throw new ArgumentNullException(nameof(storableObject), "Cannot be null");
            }
            var storedObjects = this.StoredObjects.ToList();
            storedObjects.Add(storableObject);
            this.StoredObjects = storedObjects;
        }

        public void RemoveStoredObject(IStorable storableObject)
        {
            if (storableObject == null)
            {
                throw new ArgumentNullException(nameof(storableObject), "Cannot be null");
            }
            var storedObjects = this.StoredObjects.ToList();
            storedObjects.Remove(storableObject);
            this.StoredObjects = storedObjects;
        }
    }
}
