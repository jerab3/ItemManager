using Interfaces.StorageLocations;

namespace Objects.StorageLocations
{
    public class StorageLocation(int id, string locationName) : IStorageLocation
    {
        public int Id { get; } = id;

        public string LocationName { get; } = locationName;
    }
}
