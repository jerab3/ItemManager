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
        public void IsWebAddressValid_ValidArgumentWithUrl_ReturnsTrue()
        {
            //Arrange
            var eshop = new Eshop(0, "Alza", "https://www.alza.cz");

            //Act
            var result = eshop.IsWebAddressValid();

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsWebAddressValid_ValidArgumentWithoutUrl_ReturnsFalse()
        {
            //Arrange
            var eshop = new Eshop(0, "Alza", "www.alza.cz");

            //Act
            var result = eshop.IsWebAddressValid();

            //Assert
            result.Should().BeFalse();
        }


        [Fact]
        public void Constructor_ValidArgumentsWithItemsList_SetsValuesCorectly()
        {
            //Arrange
            var mockPurchasedItem1 = new Mock<IItem>();
            var mockPurchasedItem2 = new Mock<IItem>();
            List<IItem> purchasedItemsList = new List<IItem>() { mockPurchasedItem1.Object, mockPurchasedItem2.Object };

            //Act
            var eshop = new Eshop(0, "Alza", "https://www.alza.cz", purchasedItemsList);

            //Assert
            using (new AssertionScope())
            {
                eshop.Id.Should().Be(0);
                eshop.Name.Should().Be("Alza");
                eshop.WebAddress.Should().Be("https://www.alza.cz");
                eshop.PurchasedItems.Should().HaveCount(c => c == 2);
            }
        }

        [Fact]
        public void Constructor_ValidArgumentsWithoutItemList_SetsValuesCorectly()
        {
            //Act
            var eshop = new Eshop(0, "Alza", "https://www.alza.cz");

            //Assert
            using (new AssertionScope())
            {
                eshop.Id.Should().Be(0);
                eshop.Name.Should().Be("Alza");
                eshop.WebAddress.Should().Be("https://www.alza.cz");
                eshop.PurchasedItems.Should().BeNull();
            }
        }

        [Fact]
        public void Constructor_InvalidArguments_RaisesException()
        {
            //Arrange
            Action constructor1 = () => new Eshop(0, "Alza", "");
            Action constructor2 = () => new Eshop(0, "Alza", null);
            Action constructor3 = () => new Eshop(0, "Alza", "  ");
            Action constructor4 = () => new Eshop(0, "", "url");
            Action constructor5 = () => new Eshop(0, null, "url");
            Action constructor6 = () => new Eshop(0, "  ", "url");

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
    }
}
