using Xunit;
using Moq;
using Interfaces.StorageLocations;
using Objects.Accessories;
using Objects.ObjectProperties;

namespace ItemManager.Tests
{
    public class AccessoryTests
    {
        #region StorableAccessory
        [Fact]
        public void StorableAccessory_Constructor_Values_Test()
        {
            var mockStorageLocation = new Mock<IStorageLocation>();
            mockStorageLocation.Setup(x => x.LocationName).Returns("Sklep");

            var accessory = new StorableAccessory(0, "Test accessory", mockStorageLocation.Object);

            Assert.Equal(0, accessory.Id);
            Assert.Equal("Test accessory", accessory.AccessoryName);
            Assert.Equal(mockStorageLocation.Object, accessory.StorageLocation);
            Assert.Equal("Sklep", mockStorageLocation.Object.LocationName);
        }

        [Fact]
        public void StorableAccessory_Constructor_Exceptions_Test()
        {
            var mockStorageLocation = new Mock<IStorageLocation>();

            Assert.Throws<ArgumentException>(() => new StorableAccessory(1, null, mockStorageLocation.Object));
            Assert.Throws<ArgumentException>(() => new StorableAccessory(1, "  ", mockStorageLocation.Object));
            Assert.Throws<ArgumentException>(() => new StorableAccessory(1, "", mockStorageLocation.Object));
            Assert.Throws<ArgumentNullException>(() => new StorableAccessory(1, "Test accessory", null));
        }
        #endregion
        #region UsableStorableAccessory
        [Fact]
        public void UsableStorableAccessory_Constructor_BeingUsed_Values_Test()
        {
            var usableAccessory = new UsableStoreableAccessory(0, "Kabel", "Zapojeno v PC");

            Assert.Equal(0, usableAccessory.Id);
            Assert.Equal("Kabel", usableAccessory.AccessoryName);
            Assert.True(usableAccessory.IsBeingUsed);
            Assert.Equal("Zapojeno v PC", usableAccessory.UsageDescription);
        }

        [Fact]
        public void UsableStorableAccessory_Constructor_NotBeingUsed_Values_Test()
        {
            var mockStorageLocation = new Mock<IStorageLocation>();
            mockStorageLocation.Setup(x => x.LocationName).Returns("Sklep");

            var usableAccessory = new UsableStoreableAccessory(0, "Kabel", mockStorageLocation.Object);

            Assert.Equal(0, usableAccessory.Id);
            Assert.Equal("Kabel", usableAccessory.AccessoryName);
            Assert.False(usableAccessory.IsBeingUsed);
            Assert.Equal(mockStorageLocation.Object, usableAccessory.StorageLocation);
            Assert.Equal("Sklep", mockStorageLocation.Object.LocationName);
        }

        [Fact]
        public void UsableStorableAccessory_Constructor_Exceptions_Test()
        {
            var mockStorageLocation = new Mock<IStorageLocation>();

            Assert.Throws<ArgumentException>(() => new UsableStoreableAccessory(0, null, mockStorageLocation.Object));
            Assert.Throws<ArgumentException>(() => new UsableStoreableAccessory(0, "", mockStorageLocation.Object));
            Assert.Throws<ArgumentException>(() => new UsableStoreableAccessory(0, "  ", mockStorageLocation.Object));

            Assert.Throws<ArgumentException>(() => new UsableStoreableAccessory(0, null, "Zapojen v PC"));
            Assert.Throws<ArgumentException>(() => new UsableStoreableAccessory(0, "", "Zapojen v PC"));
            Assert.Throws<ArgumentException>(() => new UsableStoreableAccessory(0, "  ", "Zapojen v PC"));

            Assert.Throws<ArgumentException>(() => new UsableStoreableAccessory(0, "Kabel", usageDescription:null));
            Assert.Throws<ArgumentException>(() => new UsableStoreableAccessory(0, "Kabel", ""));
            Assert.Throws<ArgumentException>(() => new UsableStoreableAccessory(0, "Kabel", "  "));

            Assert.Throws<ArgumentNullException>(() => new UsableStoreableAccessory(0, "Kabel", storageLocation:null));
        }
       
        [Fact]
        public void UsableStorableAccessory_StartUsingAccessory_Test()
        {
            var mockStorageLocation = new Mock<IStorageLocation>();
            var usableAccessory = new UsableStoreableAccessory(0, "Kabel", mockStorageLocation.Object);

            usableAccessory.StartUsing("Pripojen k PC");

            Assert.Null(usableAccessory.StorageLocation);
            Assert.True(usableAccessory.IsBeingUsed);
            Assert.Equal("Pripojen k PC", usableAccessory.UsageDescription);
        }

        [Fact]
        public void UsableStorableAccessory_StartUsingAccessory_Exceptions_Test()
        {
            var mockStorageLocation = new Mock<IStorageLocation>();
            var usableAccessory = new UsableStoreableAccessory(0, "Kabel", mockStorageLocation.Object);

            Assert.Throws<ArgumentException>(() => usableAccessory.StartUsing(null));
            Assert.Throws<ArgumentException>(() => usableAccessory.StartUsing("   "));
            Assert.Throws<ArgumentException>(() => usableAccessory.StartUsing(""));
        }

        [Fact]
        public void UsableStorableAccessory_StopUsingAccessory_Test()
        {
            var mockStorageLocation = new Mock<IStorageLocation>();
            var usableAccessory = new UsableStoreableAccessory(0, "Kabel", "Pripojen k PC");

            usableAccessory.StopUsing(mockStorageLocation.Object);

            Assert.Null(usableAccessory.UsageDescription);
            Assert.False(usableAccessory.IsBeingUsed);
            Assert.Equal(usableAccessory.StorageLocation, mockStorageLocation.Object);
        }

        [Fact]
        public void UsableStorableAccessory_StopUsingAccessory_Exceptions_Test()
        {
            var mockStorageLocation = new Mock<IStorageLocation>();
            var usableAccessory = new UsableStoreableAccessory(0, "Kabel", "Pripojen k PC");

            Assert.Throws<ArgumentNullException>(() => usableAccessory.StopUsing(null));
        }

        #endregion
    }
}
