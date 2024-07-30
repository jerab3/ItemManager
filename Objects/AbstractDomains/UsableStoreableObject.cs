using Domains.AbstractDomains;
using Interfaces.DomainProperties;
using Interfaces.Location;

namespace Domains.ObjectProperties
{
    /// <summary>
    /// Provides a base class for objects that can be identified by an ID and a name,
    /// be stored in a location and actively used.
    /// It includes properties and methods to manage usage state and storage location.
    /// </summary>
    public abstract class UsableStoreableObject : StorableObject, IUsableStorable
    {
        public bool IsBeingUsed { get; private set; }

        private IStorageLocation? storageLocation;
        public override IStorageLocation? StorageLocation 
        {
            get 
            { 
                return storageLocation; 
            }
            set 
            {
                if (IsBeingUsed)
                {
                    throw new InvalidOperationException($"Cannot set {nameof(StorageLocation)} while {nameof(IsBeingUsed)} is true");
                }
                if (value == null) 
                {
                    throw new ArgumentNullException(nameof(StorageLocation), "Cannot be null");
                }
                storageLocation = value;
            }
        }
        private string? usageDescription;
        public string? UsageDescription
        {
            get
            {
                return usageDescription;
            }
            set
            {
                if (!IsBeingUsed)
                {
                    throw new InvalidOperationException($"Cannot set {nameof(UsageDescription)} while {nameof(IsBeingUsed)} is false");
                }
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(UsageDescription), "Cannot be null");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(UsageDescription), "Cannot be empty or contain only white spaces");
                }

                usageDescription = value;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="UsableStoreableObject"></see> that is currently stored"
        /// </summary>
        protected UsableStoreableObject(int id, string name, IStorageLocation storageLocation)
            :base(id,name)
        {
            this.IsBeingUsed = false;

            this.StorageLocation = storageLocation;
            storageLocation.AddStoredObject(this);
            
            this.usageDescription = null;
        }
        /// <summary>
        /// Creates an instance of <see cref="UsableStoreableObject"></see> that is currently being used"
        /// </summary>
        protected UsableStoreableObject(int id, string name, string usageDescription)
            :base(id,name)
        {
            this.IsBeingUsed = true;
            
            this.UsageDescription = usageDescription;

            this.storageLocation = null;
        }

        public void StartUsing(string usageDescription)
        {
            this.IsBeingUsed = true;
            try
            {
                this.UsageDescription = usageDescription;
                this.StorageLocation.RemoveStoredObject(this);
                this.storageLocation = null;
            }
            catch (Exception e)
            {
                this.IsBeingUsed = false;
                throw;
            }
            
        }
        public void StopUsing(IStorageLocation storageLocation)
        {
            this.IsBeingUsed = false;
            try
            {
                this.StorageLocation = storageLocation;
                this.StorageLocation.AddStoredObject(this);
                this.usageDescription = null;
            }
            catch (Exception e)
            {
                this.IsBeingUsed = true;
                throw;
            }
        }
    }
}
