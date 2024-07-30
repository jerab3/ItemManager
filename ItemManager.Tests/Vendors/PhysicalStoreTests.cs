using Domains.Vendors;
using FluentAssertions.Execution;
using FluentAssertions;
using Xunit;
using Interfaces.Items;
using Moq;

namespace ItemManager.Tests.Vendors
{
    public class PhysicalStoreTests
    {
        [Fact]
        public void Constructor_ValidArgumentsWithItemList_SetsValuesCorectly()
        {
            //Arrange
            var mockPurchasedItem1 = new Mock<IItem>();
            var mockPurchasedItem2 = new Mock<IItem>();
            List<IItem> purchasedItemsList = new List<IItem>() { mockPurchasedItem1.Object, mockPurchasedItem2.Object };

            //Act
            var store = new PhysicalStore("Alza", "Vodni 57", "Brno", purchasedItemsList);

            //Assert
            using (new AssertionScope())
            {
                store.Name.Should().Be("Alza");
                store.Address.Should().Be("Vodni 57");
                store.City.Should().Be("Brno");
                store.PurchasedItems.Should().HaveCount(c => c == 2);
            }
        }

        [Fact]
        public void Constructor_ValidArgumentsWithoutItemList_SetsValuesCorectly()
        {
            //Act
            var store = new PhysicalStore("Alza", "Vodni 57", "Brno");

            //Assert
            using (new AssertionScope())
            {
                store.Name.Should().Be("Alza");
                store.Address.Should().Be("Vodni 57");
                store.City.Should().Be("Brno");
                store.PurchasedItems.Should().BeEmpty();
            }
        }

        [Fact]
        public void Constructor_InvalidArguments_RaisesException()
        {
            //Arrange
            Action constructor1 = () => new PhysicalStore("Alza", "Vodni 57", null);
            Action constructor2 = () => new PhysicalStore("Alza", "Vodni 57", "");
            Action constructor3 = () => new PhysicalStore("Alza", "Vodni 57", "   ");
            Action constructor4 = () => new PhysicalStore("Alza", null, "Brno");
            Action constructor5 = () => new PhysicalStore("Alza", "  ", "Brno");
            Action constructor6 = () => new PhysicalStore("Alza", "", "Brno");
            Action constructor7 = () => new PhysicalStore(null, "Vodni 57", "Brno");
            Action constructor8 = () => new PhysicalStore("", "Vodni 57", "Brno");
            Action constructor9 = () => new PhysicalStore("  ", "Vodni 57", "Brno");

            //Act & Assert
            using (new AssertionScope())
            {
                constructor1.Should().Throw<ArgumentNullException>();
                constructor2.Should().Throw<ArgumentException>();
                constructor3.Should().Throw<ArgumentException>();
                constructor4.Should().Throw<ArgumentNullException>();
                constructor5.Should().Throw<ArgumentException>();
                constructor6.Should().Throw<ArgumentException>();
                constructor7.Should().Throw<ArgumentNullException>();
                constructor8.Should().Throw<ArgumentException>();
                constructor9.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void AddPurchasedItem_ValidArguments_AddsItem()
        {
            //Arrange
            var mockItem = new Mock<IItem>();
            var physicalStore = new PhysicalStore("Alza", "Vodni 97", "Brno");

            //Act
            physicalStore.AddPurchasedItem(mockItem.Object);

            //Assert
            physicalStore.PurchasedItems.Should().HaveCount(c => c == 1);
        }

        [Fact]
        public void RemovePurchasedItem_ValidArguments_AddsItem()
        {
            //Arrange
            var mockItem1 = new Mock<IItem>();
            var mockItem2 = new Mock<IItem>();
            List<IItem> items = new List<IItem>() { mockItem1.Object, mockItem2.Object };
            var physicalStore = new PhysicalStore("Alza", "Vodni 97", "Brno", items);

            //Act
            physicalStore.RemovePurchasedItem(mockItem1.Object);

            //Assert
            physicalStore.PurchasedItems.Should().HaveCount(c => c == 1);
        }

        [Fact]
        public void AddPurchasedItem_InvalidArguments_RaisesException()
        {
            //Arrange
            var physicalStore = new PhysicalStore("Alza", "Vodni 97", "Brno");
            Action addPurchasedItem = () => physicalStore.AddPurchasedItem(null);


            //Act & Assert
            addPurchasedItem.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RemovePurchasedItem_InvalidArguments_RaisesException()
        {
            //Arrange
            var mockItem1 = new Mock<IItem>();
            var mockItem2 = new Mock<IItem>();
            List<IItem> items = new List<IItem>() { mockItem1.Object, mockItem2.Object };

            var physicalStore = new PhysicalStore("Alza", "Vodni 97", "Brno");

            Action removePurchasedItem = () => physicalStore.RemovePurchasedItem(null);

            //Act & Assert
            removePurchasedItem.Should().Throw<ArgumentNullException>();
        }
    }
}
