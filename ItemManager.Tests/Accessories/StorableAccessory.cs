using Domains.Accessories;
using FluentAssertions;
using FluentAssertions.Execution;
using Interfaces.Location;
using Moq;
using Xunit;

namespace ItemManager.Tests.Accessories
{
    public class StorableAccessoryTests
    {
        [Fact]
        public void Constructor_ValidArguments_SetsValuesCorectly()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();

            //Act
            var accessory = new StorableAccessory(0, "Test accessory", mockStorageLocation.Object);

            //Assert
            using (new AssertionScope())
            {
                accessory.Id.Should().Be(0);
                accessory.Name.Should().Be("Test accessory");
                accessory.StorageLocation.Should().Be(mockStorageLocation.Object);
            }
        }

        [Fact]
        public void Constructor_InvalidNameArguments_RaisesException()
        {
            //Arrange
            var mockStorageLocation = new Mock<IStorageLocation>();
            
            Action construct1 = () => new StorableAccessory(1, null, mockStorageLocation.Object);
            Action construct2 = () => new StorableAccessory(1, "  ", mockStorageLocation.Object);
            Action construct3 = () => new StorableAccessory(1, "", mockStorageLocation.Object);

            //Act & Assert
            using (new AssertionScope()) 
            { 
            construct1.Should().Throw<ArgumentNullException>();
            construct2.Should().Throw<ArgumentException>();
            construct3.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void Constructor_NullLocationArgument_RaisesException()
        {
            //Arrange
            Action construct1 = () => new StorableAccessory(1, "Test", null);

            //Act & Assert
            construct1.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void SetStorageLocation_ValidArguments_ChangesLocation()
        {
            //Arrange
            var mockStorageLocation1 = new Mock<IStorageLocation>();
            var mockStorageLocation2 = new Mock<IStorageLocation>();
            
            var accessory = new StorableAccessory(0, "Test accessory", mockStorageLocation1.Object);

            //Act
            accessory.SetStorageLocation(mockStorageLocation2.Object);

            //Assert
            accessory.StorageLocation.Should().Be(mockStorageLocation2.Object);
        }

        [Fact]
        public void SetStorageLocation_NullArgument_RaisesException()
        {
            //Arrange
            var mockStorageLocation1 = new Mock<IStorageLocation>();
            var accessory = new StorableAccessory(0, "Test accessory", mockStorageLocation1.Object);
            
            Action setStorageLocation = () => accessory.SetStorageLocation(null);

            //Act & Assert
            setStorageLocation.Should().Throw<ArgumentNullException>();
        }
    }
}
