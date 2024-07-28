using Interfaces.Accessories;
using Interfaces.ObjectProperties;
using Interfaces.StorageLocations;
using Objects.ObjectProperties;

namespace Objects.Accessories
{
    /// <summary>
    /// <see cref="Accessory"/> serves as a template for derived classes. 
    /// </summary>
    public abstract class Accessory : IAccessory
    {
        public int Id { get; }

        private string _accessoryName;
        public string AccessoryName
        {
            get { return _accessoryName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException($"Cannot set {nameof(AccessoryName)} to null empty string or only white spaces");
                }
                _accessoryName = value;
            }
        }

        protected Accessory(int id, string acessorryName)
        {
            if (string.IsNullOrWhiteSpace(acessorryName))
                throw new ArgumentException(nameof(acessorryName), "Cannot be null, empty or contain only white spaces");

            this.Id = id;
            this.AccessoryName = acessorryName;
        }
    }
    
    /// <summary>
    /// <see cref="StorableAccessory"/> represents accessories, which cannot be used a can be only stored. For example paper documents.
    /// </summary>
    public class StorableAccessory : Accessory, IStoreable
    {
        public IStorageLocation StorageLocation { get; set; }

        public StorableAccessory(int id, string accessoryName, IStorageLocation storageLocation)
            :base(id, accessoryName)
        {
            if (storageLocation == null)
            {
                throw new ArgumentNullException(nameof(storageLocation), "Cannot be null");
            }

            this.StorageLocation = storageLocation;
        }
    }
    
    /// <summary>
    /// <see cref="UsableAccessory"/> represents accessories, which can be used and stored. For example cables.
    /// </summary>
    public class UsableStoreableAccessory : UsableStoreable, IAccessory
    {
        public int Id { get; }
        public string AccessoryName { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="UsableStoreableAccessory"/> as item, that we are currently using.
        /// </summary>
        public UsableStoreableAccessory(int id, string acessorryName, string usageDescription)
            : base(usageDescription)
        {
            if (string.IsNullOrWhiteSpace(acessorryName)) {
                throw new ArgumentException(nameof(acessorryName), "Cannot be null, empty or contain only white spaces");
            }
            this.Id = id;
            this.AccessoryName = acessorryName;
        }
        /// <summary>
        /// Initializes a new instance of <see cref="UsableStoreableAccessory"/> as item, that is currently stored.
        /// </summary>
        public UsableStoreableAccessory(int id, string acessorryName, IStorageLocation storageLocation)
            : base(storageLocation)
        {
            if (string.IsNullOrWhiteSpace(acessorryName))
            {
                throw new ArgumentException(nameof(acessorryName), "Cannot be null, empty or contain only white spaces");
            }
            this.Id = id;
            this.AccessoryName = acessorryName;
        }
    } 
}
