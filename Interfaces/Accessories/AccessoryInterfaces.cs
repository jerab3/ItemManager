using Interfaces.StorageLocations;

namespace Interfaces.Accessories
{
    public interface IAccessory
    {
        int Id { get;}
        string AccessoryName { get; set; }

    }
}
