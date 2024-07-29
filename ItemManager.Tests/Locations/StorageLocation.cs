﻿using Domains.Locations;
using FluentAssertions;
using FluentAssertions.Execution;
using Interfaces.DomainProperties;
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
            var storageLocation = new StorageLocation(0, "Basement", storedItemsList);

            //Assert
            using (new AssertionScope())
            {
                storageLocation.Id.Should().Be(0);
                storageLocation.Name.Should().Be("Basement");
                storageLocation.StoredObjects.Should().HaveCount(c => c == 2);
            }
        }

        [Fact]
        public void Constructor_ValidArgumentsWithoutStoredObjectsList_SetsValuesCorectly()
        {
            //Act
            var storageLocation = new StorageLocation(0, "Basement");

            //Assert
            using (new AssertionScope())
            {
                storageLocation.Id.Should().Be(0);
                storageLocation.Name.Should().Be("Basement");
                storageLocation.StoredObjects.Should().BeNull();
            }
        }

        [Fact]
        public void Constructor_InvalidArguments_RaisesException()
        {
            //Arrange
            Action constructor1 = () => new StorageLocation(0, null);
            Action constructor2 = () => new StorageLocation(0, "");
            Action constructor3 = () => new StorageLocation(0, "   ");

            //Act & Assert
            using (new AssertionScope())
            {
                constructor1.Should().Throw<ArgumentNullException>();
                constructor2.Should().Throw<ArgumentException>();
                constructor3.Should().Throw<ArgumentException>();
            }
        }
    }
}
