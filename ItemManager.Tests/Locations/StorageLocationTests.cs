using Domains.Locations;
using Domains.Vendors;
using FluentAssertions;
using FluentAssertions.Execution;
using Interfaces.DomainProperties;
using Interfaces.Items;
using Moq;
using Xunit;

namespace ItemManager.Tests.Locations
{
    public class StorageLocationTests
    {
        [Fact]
        public void Constructor_ValidArgumentsWithStoredObjectsList_SetsValuesCorectly()
        {
            //Arrange
            var mockStorableItem1 = new Mock<IStorable>();
            var mockStorableItem2 = new Mock<IStorable>();
            List<IStorable> storedItemsList = new List<IStorable>() { mockStorableItem1.Object, mockStorableItem2.Object };

            //Act
            var storageLocation = new StorageLocation("Basement", storedItemsList);

            //Assert
            using (new AssertionScope())
            {
                storageLocation.Name.Should().Be("Basement");
                storageLocation.StoredObjects.Should().HaveCount(c => c == 2);
            }
        }

        [Fact]
        public void Constructor_ValidArgumentsWithoutStoredObjectsList_SetsValuesCorectly()
        {
            //Act
            var storageLocation = new StorageLocation("Basement");

            //Assert
            using (new AssertionScope())
            {
                storageLocation.Name.Should().Be("Basement");
                storageLocation.StoredObjects.Should().BeEmpty();
            }
        }

        [Fact]
        public void Constructor_InvalidArguments_RaisesException()
        {
            //Arrange
            Action constructor1 = () => new StorageLocation(null);
            Action constructor2 = () => new StorageLocation("");
            Action constructor3 = () => new StorageLocation("   ");

            //Act & Assert
            using (new AssertionScope())
            {
                constructor1.Should().Throw<ArgumentNullException>();
                constructor2.Should().Throw<ArgumentException>();
                constructor3.Should().Throw<ArgumentException>();
            }
        }
        [Fact]
        public void AddStoredObject_ValidArguments_AddsObject()
        {
            //Arrange
            var mockItem = new Mock<IStorable>();
            var storageLocation = new StorageLocation("Basement");

            //Act
            storageLocation.AddStoredObject(mockItem.Object);

            //Assert
            storageLocation.StoredObjects.Should().HaveCount(c => c == 1);
        }

        [Fact]
        public void RemoveStoredObject_ValidArguments_AddsObject()
        {
            //Arrange
            var mockItem1 = new Mock<IStorable>();
            var mockItem2 = new Mock<IStorable>();
            List<IStorable> items = new List<IStorable>() { mockItem1.Object, mockItem2.Object };
            var storageLocation = new StorageLocation("Basement", items);

            //Act
            storageLocation.RemoveStoredObject(mockItem1.Object);

            //Assert
            storageLocation.StoredObjects.Should().HaveCount(c => c == 1);
        }

        [Fact]
        public void AddStoredObject_InvalidArguments_RaisesException()
        {
            //Arrange
            var storageLocation = new StorageLocation("Basement");
            Action addStoredObject = () => storageLocation.AddStoredObject(null);


            //Act & Assert
            addStoredObject.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RemoveStoredObject_InvalidArguments_RaisesException()
        {
            //Arrange
            var mockItem1 = new Mock<IStorable>();
            var mockItem2 = new Mock<IStorable>();
            List<IStorable> items = new List<IStorable>() { mockItem1.Object, mockItem2.Object };

            var storageLocation = new StorageLocation("Basement", items);

            Action removeStoredObject = () => storageLocation.RemoveStoredObject(null);

            //Act & Assert
            removeStoredObject.Should().Throw<ArgumentNullException>();
        }
    }
}
