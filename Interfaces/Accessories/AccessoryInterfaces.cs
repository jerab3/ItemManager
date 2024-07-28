using Interfaces.StorageLocations;

namespace Interfaces.Accessories
{
    public interface IAccessory
    {
        int Id { get;}
        string Name { get; set; }
        IStorageLocation? Location { get; set; }

    }
    public interface IUsableAccessory : IAccessory
    {
        bool IsBeingUsed { get; }
        string? UsageDescription { get; }

        void SetUsageStatus(bool isBeingUsed, string usageDescription, IStorageLocation? location = null);
    }
}
