using Interfaces.DomainProperties;
using Interfaces.Location;

namespace Domains.AbstractDomains
{
    /// <summary>
    /// Provides a base class for objects that can be stored in a specific location
    /// and identified by an ID and a name.
    /// </summary>
    public abstract class StorableObject : IdentifiableObject, IStorable
    {
        private IStorageLocation storageLocation;
        public virtual IStorageLocation StorageLocation
        {
            get
            {
                return storageLocation;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(storageLocation), "Cannot be null");
                }
                storageLocation = value;
            }
        }
        
        protected StorableObject(int id, string name, IStorageLocation storageLocation)
            :base(id, name)
        {
            this.StorageLocation = storageLocation;
            storageLocation.AddStoredObject(this);
        }
        /// <summary>
        /// Serves as constructor for classes that override StorageLocation setter
        /// </summary>
        protected StorableObject(int id, string name)
            : base(id, name) 
        {
            this.StorageLocation = null;
        }

    }
}
