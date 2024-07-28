using Xunit;
using Objects.StorageLocations;

namespace ItemManager.Tests
{
    public class StorageLocationTests
    {
        #region StorageLocation
        [Fact]
        public void StorageLocation_Constructor_Values_Test()
        {
            var storageLocation = new StorageLocation(0, "Sklep");

            Assert.Equal(0, storageLocation.Id);
            Assert.Equal("Sklep", storageLocation.LocationName);
        }

        [Fact]
        public void StorageLocation_Constructor_Exceptions_Test()
        {
            Assert.Throws<ArgumentException>(() => new StorageLocation(0, null));
            Assert.Throws<ArgumentException>(() => new StorageLocation(0, "  "));
            Assert.Throws<ArgumentException>(() => new StorageLocation(0, ""));
        }
        #endregion
    }
}
