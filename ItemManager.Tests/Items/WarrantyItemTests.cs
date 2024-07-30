using FluentAssertions;
using FluentAssertions.Execution;
using Interfaces.Accessories;
using Interfaces.Vendor;
using Moq;
using Objects.Items;
using Xunit;

namespace ItemManager.Tests.Items
{
    public class WarrantyItemTests
    {
        [Fact]
        public void Constructor_ValidArgumentsWithoutAccessories_StoresCorrectValues()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor = new Mock<IVendor>();

            //Act
            var item = new WarrantyItem(0, "PC", dateTime, 1.5m, "In the living room", mockVendor.Object,dateTime);

            //Assert
            using (new AssertionScope())
            {
                item.Id.Should().Be(0);
                item.Name.Should().Be("PC");
                item.PurchaseDate.Should().Be(dateTime);
                item.Cost.Should().Be(1.5m);
                item.UsageDescription.Should().Be("In the living room");
                item.Vendor.Should().Be(mockVendor.Object);
                item.IsBeingUsed.Should().BeTrue();
                item.Accessories.Should().HaveCount(c => c == 0);
                item.WarrantyEndDate.Should().Be(dateTime);
            }
        }

        [Fact]
        public void Constructor_ValidArgumentsWithAccessories_StoresCorrectValues()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor = new Mock<IVendor>();

            var mockAccessory1 = new Mock<IAccessory>();
            var mockAccessory2 = new Mock<IAccessory>();
            List<IAccessory> accessories = new List<IAccessory>() { mockAccessory1.Object, mockAccessory2.Object };

            //Act
            var item = new WarrantyItem(0, "PC", dateTime, 1.5m, "In the living room", mockVendor.Object, dateTime, accessories);

            //Assert
            item.Accessories.Should().HaveCount(c => c == 2);
        }

        [Fact]
        public void Constructor_InvalidArguments_RaisesException()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            Action constructor = () => new WarrantyItem(0, "PC", dateTime, 1.5m, "In the living room", null, dateTime);

            //Act & Assert
            constructor.Should().Throw<ArgumentNullException>();
        }
    }
}
