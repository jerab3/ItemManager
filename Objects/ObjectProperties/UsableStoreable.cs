using Interfaces.ObjectProperties;
using Interfaces.StorageLocations;

namespace Objects.ObjectProperties
{
    public abstract class UsableStoreable : IStoreable, IUsable
    {
        public bool IsBeingUsed { get; private set; }

        private IStorageLocation? _storageLocation;
        public IStorageLocation? StorageLocation
        {
            get { return _storageLocation; }
            set
            {
                if (value != null && IsBeingUsed)
                {
                    throw new InvalidOperationException($"Cannot set {nameof(StorageLocation)} while {nameof(IsBeingUsed)} is true");
                }
                if (value == null && !IsBeingUsed)
                {
                    throw new InvalidOperationException($"Cannot set {nameof(StorageLocation)} to null while {nameof(IsBeingUsed)} is false");
                }
                _storageLocation = value;
            }
        }
        
        private string? _usageDescription;
        public string? UsageDescription 
        {
            get { return _usageDescription; }
            set
            {
                if (value != null && !IsBeingUsed)
                {
                    throw new InvalidOperationException($"Cannot set {nameof(_usageDescription)} while {nameof(IsBeingUsed)} is false");
                }
                if (value == null && IsBeingUsed)
                {
                    throw new InvalidOperationException($"Cannot set {nameof(_usageDescription)} to null while {nameof(IsBeingUsed)} is true");
                }
                _usageDescription = value;
            }
        }

        protected UsableStoreable(IStorageLocation storageLocation) 
        {
            if (storageLocation == null)
            {
                throw new ArgumentNullException(nameof(storageLocation), "Cannot be null");
            }

            this.IsBeingUsed = false;
            this.StorageLocation = storageLocation;
            this.UsageDescription = null;
        }
        protected UsableStoreable(string usageDescription) 
        {
            if (string.IsNullOrWhiteSpace(usageDescription))
            {
                throw new ArgumentException(nameof(usageDescription), "Cannot be null, empty or contain only white spaces");
            }

            this.IsBeingUsed = true;
            this.UsageDescription = usageDescription;
            this.StorageLocation = null;
        }

        public void StartUsing(string usageDescription)
        {
            if (string.IsNullOrWhiteSpace(usageDescription))
            {
                throw new ArgumentException(nameof(usageDescription), "Cannot be null, empty or contain only white spaces");
            }

            this.IsBeingUsed = true;
            this.UsageDescription = usageDescription;
            this.StorageLocation = null;
        }
        public void StopUsing(IStorageLocation storageLocation)
        {
            if (storageLocation == null)
            {
                throw new ArgumentNullException(nameof(storageLocation), "Cannot be null");
            }

            this.IsBeingUsed = false;
            this.StorageLocation = storageLocation;
            this.UsageDescription = null;
        }
    }
}
