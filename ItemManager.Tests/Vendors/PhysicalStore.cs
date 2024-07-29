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
            var store = new PhysicalStore(0, "Alza", "Vodni 57", "Brno", purchasedItemsList);

            //Assert
            using (new AssertionScope())
            {
                store.Id.Should().Be(0);
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
            var store = new PhysicalStore(0, "Alza", "Vodni 57", "Brno");

            //Assert
            using (new AssertionScope())
            {
                store.Id.Should().Be(0);
                store.Name.Should().Be("Alza");
                store.Address.Should().Be("Vodni 57");
                store.City.Should().Be("Brno");
                store.PurchasedItems.Should().BeNull();
            }
        }

        [Fact]
        public void Constructor_InvalidArguments_RaisesException()
        {
            //Arrange
            Action constructor1 = () => new PhysicalStore(0, "Alza", "Vodni 57", null);
            Action constructor2 = () => new PhysicalStore(0, "Alza", "Vodni 57", "");
            Action constructor3 = () => new PhysicalStore(0, "Alza", "Vodni 57", "   ");
            Action constructor4 = () => new PhysicalStore(0, "Alza", null, "Brno");
            Action constructor5 = () => new PhysicalStore(0, "Alza", "  ", "Brno");
            Action constructor6 = () => new PhysicalStore(0, "Alza", "", "Brno");
            Action constructor7 = () => new PhysicalStore(0, null, "Vodni 57", "Brno");
            Action constructor8 = () => new PhysicalStore(0, "", "Vodni 57", "Brno");
            Action constructor9 = () => new PhysicalStore(0, "  ", "Vodni 57", "Brno");

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
    }
}
