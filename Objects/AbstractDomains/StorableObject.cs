using Interfaces.DomainProperties;
using Interfaces.Location;
using Objects.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.AbstractDomains
{
    /// <summary>
    /// Provides a base class for objects that can be stored in a specific location
    /// and identified by an ID and a name.
    /// </summary>
    public abstract class StorableObject : IdentifiableObject, IStorable
    {
        public IStorageLocation StorageLocation { get; private set; }
        
        protected StorableObject(int id, string name, IStorageLocation storageLocation)
            :base(id, name)
        {
            SetStorageLocation(storageLocation);
        }

        public void SetStorageLocation(IStorageLocation storageLocation)
        {
            if (storageLocation == null)
                throw new ArgumentNullException(nameof(storageLocation), "Cannot be null");
            this.StorageLocation = storageLocation;
        }
    }
}
