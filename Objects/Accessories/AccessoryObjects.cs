using Interfaces.Accessories;
using Interfaces.StorageLocations;

namespace Objects.Accessories
{
    public class Accessory : IAccessory
    {
        public int Id { get; }
        public string Name { get; set; }
        public IStorageLocation? Location { get; set; }

        public Accessory(int id, string name, IStorageLocation? location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location), "Location cannot be null for Accessorry");
            }

            Id = id;
            Name = name;
            Location = location;
        }
    }

    public class UsableAccessory : Accessory, IUsableAccessory
    {
        private bool isBeingUsed;

        public bool IsBeingUsed
        {
            get { return isBeingUsed; }
            private set 
            {
                isBeingUsed = value;

                if (isBeingUsed)
                {
                    Location = null;
                }
                else
                {
                    UsageDescription = null;
                }
            }
        }
        public string? UsageDescription { get; private set; }

        public UsableAccessory(int id, string name, bool isBeingUsed, string? usageDescription, IStorageLocation? location = null)
            :base (id, name, location)
        {
            if (!isBeingUsed && location == null)
            {
                throw new ArgumentNullException(nameof(location), "Location cannot be null when the accessory is not being used");
            }

            IsBeingUsed = isBeingUsed;
            UsageDescription = usageDescription;
        }

        public void SetUsageStatus(bool isBeingUsed, string? usageDescription = null, IStorageLocation? location = null)
        {
            if (isBeingUsed && usageDescription == null)
            {
                throw new ArgumentNullException(nameof(usageDescription), "Usage description cannot be null while the accessory is being used");
            }
            if (!isBeingUsed && location == null)
            {
                throw new ArgumentNullException(nameof(location), "Location cannot be null while the accessory not is being used");
            }

            IsBeingUsed = isBeingUsed;

            if (isBeingUsed)
            {
                UsageDescription = usageDescription;
            }
            else
            {
                Location = location;
            }
        }
    }
}
