using Domains.AbstractDomains;
using Interfaces.Accessories;
using Interfaces.Location;

namespace Domains.Accessories
{
    /// <summary>
    /// <see cref="StorableAccessory"/> represents accessories, which cannot be used a can be only stored. For example paper documents.
    /// </summary>
    public class StorableAccessory : StorableObject, IAccessory
    {
        public StorableAccessory(int id, string name, IStorageLocation storageLocation)
            : base(id, name, storageLocation) { }
    }

}
