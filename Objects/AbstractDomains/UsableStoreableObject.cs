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
    public abstract class UsableStoreableObject : IdentifiableObject, IUsableStorable
    {
        public bool IsBeingUsed { get; private set; }

        public IStorageLocation? StorageLocation { get; private set; }
        
        public string? UsageDescription { get; private set; }

        /// <summary>
        /// Creates an instance of <see cref="UsableStoreableObject"></see> that is currently stored"
        /// </summary>
        protected UsableStoreableObject(int id, string name, IStorageLocation storageLocation)
            :base(id,name)
        {
            this.IsBeingUsed = false;
            SetStorageLocation(storageLocation);
            this.UsageDescription = null;
        }
        /// <summary>
        /// Creates an instance of <see cref="UsableStoreableObject"></see> that is currently being used"
        /// </summary>
        protected UsableStoreableObject(int id, string name, string usageDescription)
            :base(id,name)
        {
            this.IsBeingUsed = true;
            SetUsageDescription(usageDescription);
            this.StorageLocation = null;
        }
        public void SetStorageLocation(IStorageLocation storageLocation)
        {
            if (IsBeingUsed)
            {
                throw new InvalidOperationException($"Cannot set {nameof(StorageLocation)} while {nameof(IsBeingUsed)} is true");
            }
            if (storageLocation == null)
                throw new ArgumentNullException(nameof(storageLocation), "Cannot be null");
            this.StorageLocation = storageLocation;
        }
        
        public void SetUsageDescription(string usageDescription)
        {
            if (!IsBeingUsed)
            {
                throw new InvalidOperationException($"Cannot set {nameof(UsageDescription)} while {nameof(IsBeingUsed)} is false");
            }
            if (usageDescription == null)
                throw new ArgumentNullException(nameof(usageDescription), "Cannot be null");
            if (string.IsNullOrWhiteSpace(usageDescription))
                throw new ArgumentException(nameof(usageDescription), "Cannot be empty or contain only white spaces");

            this.UsageDescription = usageDescription;
        }

        public void StartUsing(string usageDescription)
        {
            this.IsBeingUsed = true;
            try
            {
                SetUsageDescription(usageDescription);
                this.StorageLocation = null;
            }
            catch (Exception e)
            {
                this.IsBeingUsed = false;
            }
            
        }
        public void StopUsing(IStorageLocation storageLocation)
        {
            this.IsBeingUsed = false;
            try
            {
                SetStorageLocation(storageLocation);
                this.UsageDescription = null;
            }
            catch (Exception e)
            {
                this.IsBeingUsed = true;
            }
        }
    }
}
