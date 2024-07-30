using Domains.Accessories;
using FluentAssertions;
using FluentAssertions.Execution;
using Interfaces.Location;
using Moq;
using Xunit;

namespace ItemManager.Tests.Accessories
{
    public class UsableStorableAccessoryTests
    {
        [Fact]
        public void Constructor_ValidArgumentsUsedAccessory_SetsValuesCorectly()
        {
            //Act
            var usableAccessory = new UsableStoreableAccessory(0, "Cable", "Plugged in PC");

            //Assert
            using (new AssertionScope())
            {
                usableAccessory.Id.Should().Be(0);
                usableAccessory.Name.Should().Be("Cable");
                usableAccessory.IsBeingUsed.Should().BeTrue();
                usableAccessory.UsageDescription.Should().Be("Plugged in PC");
                usableAccessory.StorageLocation.Should().BeNull();
            }
        }

        [Fact]
        public void Constructor_ValidArgumentsStoredAccessory_SetsValuesCorectly()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();

            //Act
            var usableAccessory = new UsableStoreableAccessory(0, "Cable", mockStorageLocation.Object);

            //Assert
            using (new AssertionScope())
            {
                usableAccessory.Id.Should().Be(0);
                usableAccessory.Name.Should().Be("Cable");
                usableAccessory.IsBeingUsed.Should().BeFalse();
                usableAccessory.StorageLocation.Should().Be(mockStorageLocation.Object);
                usableAccessory.UsageDescription.Should().BeNull();
            }
        }

        [Fact]
        public void Constructor_InvalidNameArguments_RaisesException()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();
            Action constructor1 = () => new UsableStoreableAccessory(0, null, mockStorageLocation.Object);
            Action constructor2 = () => new UsableStoreableAccessory(0, "", mockStorageLocation.Object);
            Action constructor3 = () => new UsableStoreableAccessory(0, "   ", mockStorageLocation.Object);

            //Act & Assert
            using (new AssertionScope())
            {
                constructor1.Should().Throw<ArgumentNullException>();
                constructor2.Should().Throw<ArgumentException>();
                constructor3.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void Constructor_InvalidUsageDescriptionArguments_RaisesException()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();
            Action constructor1 = () => new UsableStoreableAccessory(0, "Cable", usageDescription:null);
            Action constructor2 = () => new UsableStoreableAccessory(0, "Cable", "");
            Action constructor3 = () => new UsableStoreableAccessory(0, "Cable", "   ");

            //Act & Assert
            using (new AssertionScope())
            {
                constructor1.Should().Throw<ArgumentNullException>();
                constructor2.Should().Throw<ArgumentException>();
                constructor3.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void Constructor_NullLocationArgument_RaisesException()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();
            Action constructor1 = () => new UsableStoreableAccessory(0, "Cable", storageLocation: null);

            //Act & Assert
            constructor1.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void StartUsing_ValidArguments_SwitchesStateAndValues()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();
            var usableAccessory = new UsableStoreableAccessory(0, "Cable", mockStorageLocation.Object);

            //Act
            usableAccessory.StartUsing("Plugged to PC");

            //Assert
            using (new AssertionScope())
            {
                usableAccessory.StorageLocation.Should().BeNull();
                usableAccessory.IsBeingUsed.Should().BeTrue();
                usableAccessory.UsageDescription.Should().Be("Plugged to PC");
            }
        }

        [Fact]
        public void StartUsing_InvalidArguments_RaisesException()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();
            var usableAccessory = new UsableStoreableAccessory(0, "Cable", mockStorageLocation.Object);

            Action startUsingAccessory1 = () => usableAccessory.StartUsing(null);
            Action startUsingAccessory2 = () => usableAccessory.StartUsing("");
            Action startUsingAccessory3 = () => usableAccessory.StartUsing("    ");

            //Act & Assert
            using (new AssertionScope())
            {
                startUsingAccessory1.Should().Throw<ArgumentNullException>();
                startUsingAccessory2.Should().Throw<ArgumentException>();
                startUsingAccessory3.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void StopUsing_ValidArguments_SwitchesStateAndValues()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();
            var usableAccessory = new UsableStoreableAccessory(0, "Cable", "Plugged into PC");

            //Act
            usableAccessory.StopUsing(mockStorageLocation.Object);

            //Assert
            using (new AssertionScope())
            {
                usableAccessory.UsageDescription.Should().BeNull();
                usableAccessory.IsBeingUsed.Should().BeFalse();
                usableAccessory.StorageLocation.Should().Be(mockStorageLocation.Object);
            }
        }

        [Fact]
        public void StopUsing_NullArgument_RaisesException()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();
            var usableAccessory = new UsableStoreableAccessory(0, "Cable", "Plugged into PC");

            Action stopUsingAccessory = () => usableAccessory.StopUsing(null);

            //Act & Assert
            stopUsingAccessory.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ChangeStorageLocation_ValidArguments_ChangesLocation()
        {
            //Arrange
            var mockStorageLocation1 = new Mock<IStorageLocation>();
            var mockStorageLocation2 = new Mock<IStorageLocation>();

            var accessory = new UsableStoreableAccessory(0, "Test accessory", mockStorageLocation1.Object);

            //Act
            accessory.StorageLocation = mockStorageLocation2.Object;

            //Assert
            accessory.StorageLocation.Should().Be(mockStorageLocation2.Object);
        }

        [Fact]
        public void ChangeStorageLocation_NullArgument_RaisesException()
        {
            //Arrange
            var mockStorageLocation1 = new Mock<IStorageLocation>();
            var accessory = new UsableStoreableAccessory(0, "Test accessory", mockStorageLocation1.Object);

            Action setStorageLocation = () => accessory.StorageLocation = null;

            //Act & Assert
            setStorageLocation.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ChangeUsageDescription_ValidArguments_ChangesLocation()
        {
            //Arrange
            var accessory = new UsableStoreableAccessory(0, "Test accessory", "Plugged in PC");

            //Act
            accessory.UsageDescription = "Plugged in TV";

            //Assert
            accessory.UsageDescription.Should().Be("Plugged in TV");
        }

        [Fact]
        public void ChangeUsageDescription_InvalidArguments_RaisesException()
        {
            //Arrange
            var accessory = new UsableStoreableAccessory(0, "Test accessory", "Plugged in PC");

            Action setUsageDescription1 = () => accessory.StorageLocation = null;
            Action setUsageDescription2 = () => accessory.UsageDescription = "";
            Action setUsageDescription3 = () => accessory.UsageDescription = "    ";

            //Act & Assert
            using (new AssertionScope())
            {
                setUsageDescription1.Should().Throw<InvalidOperationException>();
                setUsageDescription2.Should().Throw<ArgumentException>();
                setUsageDescription3.Should().Throw<ArgumentException>();
            }
                
        }
    }
}
