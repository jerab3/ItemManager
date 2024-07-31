using Interfaces.Accessories;
using Interfaces.Location;
using Domains.ObjectProperties;

namespace Domains.Accessories
{
    /// <summary>
    /// <see cref="UsableStoreableAccessory"/> represents accessories, which can be used and stored. For example cables.
    /// </summary>
    public class UsableStoreableAccessory : UsableStoreableObject, IAccessory
    {

        /// <summary>
        /// Initializes a new instance of <see cref="UsableStoreableAccessory"/> as item, that we are currently using.
        /// </summary>
        public UsableStoreableAccessory(string name, string usageDescription)
            : base(name, usageDescription) { }

        /// <summary>
        /// Initializes a new instance of <see cref="UsableStoreableAccessory"/> as item, that is currently stored.
        /// </summary>
        public UsableStoreableAccessory(string name, IStorageLocation storageLocation)
            : base(name, storageLocation) { }
    }
}
