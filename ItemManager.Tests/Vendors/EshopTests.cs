using Domains.Vendors;
using FluentAssertions;
using FluentAssertions.Execution;
using Interfaces.Items;
using Moq;
using Xunit;

namespace ItemManager.Tests.Vendors
{
    public class EshopTests
    {


        [Fact]
        public void Constructor_ValidArgumentsWithItemsList_SetsValuesCorectly()
        {
            //Arrange
            var mockPurchasedItem1 = new Mock<IItem>();
            var mockPurchasedItem2 = new Mock<IItem>();
            List<IItem> purchasedItemsList = new List<IItem>() { mockPurchasedItem1.Object, mockPurchasedItem2.Object };

            //Act
            var eshop = new Eshop("Alza", "https://www.alza.cz", purchasedItemsList);

            //Assert
            using (new AssertionScope())
            {
                eshop.Name.Should().Be("Alza");
                eshop.WebAddress.Should().Be("https://www.alza.cz");
                eshop.PurchasedItems.Should().HaveCount(c => c == 2);
            }
        }

        [Fact]
        public void Constructor_ValidArgumentsWithoutItemList_SetsValuesCorectly()
        {
            //Act
            var eshop = new Eshop("Alza", "https://www.alza.cz");

            //Assert
            using (new AssertionScope())
            {
                eshop.Name.Should().Be("Alza");
                eshop.WebAddress.Should().Be("https://www.alza.cz");
                eshop.PurchasedItems.Should().BeEmpty();
            }
        }

        [Fact]
        public void Constructor_InvalidArguments_RaisesException()
        {
            //Arrange
            Action constructor1 = () => new Eshop("Alza", "");
            Action constructor2 = () => new Eshop("Alza", null);
            Action constructor3 = () => new Eshop("Alza", "  ");
            Action constructor4 = () => new Eshop("", "url");
            Action constructor5 = () => new Eshop(null, "url");
            Action constructor6 = () => new Eshop("  ", "url");

            //Act & Assert
            using (new AssertionScope())
            {
                constructor1.Should().Throw<ArgumentException>();
                constructor2.Should().Throw<ArgumentNullException>();
                constructor3.Should().Throw<ArgumentException>();
                constructor4.Should().Throw<ArgumentException>();
                constructor5.Should().Throw<ArgumentNullException>();
                constructor6.Should().Throw<ArgumentException>();
            }
        }
        [Fact]
        public void IsWebAddressValid_ValidArgumentWithUrl_ReturnsTrue()
        {
            //Arrange
            var eshop = new Eshop("Alza", "https://www.alza.cz");

            //Act
            var result = eshop.IsWebAddressValid();

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsWebAddressValid_ValidArgumentWithoutUrl_ReturnsFalse()
        {
            //Arrange
            var eshop = new Eshop("Alza", "www.alza.cz");

            //Act
            var result = eshop.IsWebAddressValid();

            //Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void AddPurchasedItem_ValidArguments_AddsItem()
        {
            //Arrange
            var mockItem = new Mock<IItem>();
            var eshop = new Eshop("Alza", "www.alza.cz");

            //Act
            eshop.AddPurchasedItem(mockItem.Object);

            //Assert
            eshop.PurchasedItems.Should().HaveCount(c => c == 1);
        }

        [Fact]
        public void RemovePurchasedItem_ValidArguments_AddsItem()
        {
            //Arrange
            var mockItem1 = new Mock<IItem>();
            var mockItem2 = new Mock<IItem>();
            List<IItem> items = new List<IItem>() { mockItem1.Object, mockItem2.Object };
            var eshop = new Eshop("Alza", "www.alza.cz",items);

            //Act
            eshop.RemovePurchasedItem(mockItem1.Object);

            //Assert
            eshop.PurchasedItems.Should().HaveCount(c => c == 1);
        }

        [Fact]
        public void AddPurchasedItem_InvalidArguments_RaisesException()
        {
            //Arrange
            var eshop = new Eshop("Alza", "www.alza.cz");
            Action addPurchasedItem = () => eshop.AddPurchasedItem(null);


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
            
            var eshop = new Eshop("Alza", "www.alza.cz", items);
            
            Action removePurchasedItem = () => eshop.RemovePurchasedItem(null);

            //Act & Assert
            removePurchasedItem.Should().Throw<ArgumentNullException>();
        }
    }
}
