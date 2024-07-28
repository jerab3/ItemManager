using Interfaces.StorageLocations;

namespace Objects.StorageLocations
{
    /// <summary>
    /// <see cref="StorageLocation"/> represents rooms or objects, which refer to storage locations. For example: basement.
    /// </summary>
    public class StorageLocation : IStorageLocation
    {
        public int Id { get; }

        public string LocationName { get; }

        public StorageLocation(int id, string locationName)
        {
            if (string.IsNullOrWhiteSpace(locationName))
                throw new ArgumentException(nameof(locationName), "Cannot be null, empty or contain only white spaces");

            this.Id = id;
            this.LocationName = locationName;
        }
    }
}
