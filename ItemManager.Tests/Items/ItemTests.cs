using FluentAssertions;
using FluentAssertions.Execution;
using Interfaces.Accessories;
using Interfaces.Vendor;
using Moq;
using Objects.Items;
using Xunit;

namespace ItemManager.Tests.Items
{
    public class ItemTests
    {
        [Fact]
        public void Constructor_ValidArgumentsWithoutAccessories_StoresCorrectValues()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor = new Mock<IVendor>();

            //Act
            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor.Object);

            //Assert
            using (new AssertionScope())
            {
                item.Name.Should().Be("PC");
                item.PurchaseDate.Should().Be(dateTime);
                item.Cost.Should().Be(1.5m);
                item.UsageDescription.Should().Be("In the living room");
                item.Vendor.Should().Be(mockVendor.Object);
                item.IsBeingUsed.Should().BeTrue();
                item.Accessories.Should().HaveCount(c => c == 0);
            }
        }

        [Fact]
        public void ChangingName_ValidArguments_ChangesName()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor = new Mock<IVendor>();
            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor.Object);

            //Act
            item.Name = "TV";
         
            //Assert
            item.Name.Should().Be("TV");
        }

        [Fact]
        public void ChangingName_InvalidArguments_RaisesException()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor = new Mock<IVendor>();
            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor.Object);

            Action changingName1 = () => item.Name = "";
            Action changingName2 = () => item.Name = "   ";
            Action changingName3 = () => item.Name = null;

            //Act & Assert
            using (new AssertionScope())
            {
                changingName1.Should().Throw<ArgumentException>();
                changingName2.Should().Throw<ArgumentException>();
                changingName3.Should().Throw<ArgumentNullException>();
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
            List<IAccessory> accessories = new List<IAccessory>() { mockAccessory1.Object, mockAccessory2.Object};

            //Act
            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor.Object, accessories);

            //Assert
            item.Accessories.Should().HaveCount(c => c == 2);
        }

        [Fact]
        public void Constructor_InvalidArguments_RaisesException()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            Action constructor = () => new Item("PC", dateTime, 1.5m, "In the living room", null);

            //Act & Assert
            constructor.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ChangingVendor_ValidArguments_ChangesVendor()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor1 = new Mock<IVendor>();
            var mockVendor2 = new Mock<IVendor>();
            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor1.Object);

            //Act
            item.Vendor = mockVendor2.Object;

            //Assert
            item.Vendor.Should().Be(mockVendor2.Object);
        }

        [Fact]
        public void ChangingVendor_InvalidArguments_RaisesException()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor1 = new Mock<IVendor>();
            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor1.Object);
            
            Action setVendorToNull = () => item.Vendor = null;

            //Act & Assert
            setVendorToNull.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void AddingAccessory_ValidArguments_AddsAccessory()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor1 = new Mock<IVendor>();

            var mockAccessory = new Mock<IAccessory>();

            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor1.Object);

            //Act
            item.AddAccessory(mockAccessory.Object);

            //Assert
            item.Accessories.Should().HaveCount(c => c == 1);
        }

        [Fact]
        public void AddingAccessory_InvalidArguments_RaisesException()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor1 = new Mock<IVendor>();


            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor1.Object);
            Action addNullAccessory = () => item.AddAccessory(null);

            //Act & Assert
            addNullAccessory.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RemovingAccessory_ValidArguments_RemovesAccessory()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor1 = new Mock<IVendor>();

            var mockAccessory1 = new Mock<IAccessory>();
            var mockAccessory2 = new Mock<IAccessory>();
            List<IAccessory> accessories = new List<IAccessory>() { mockAccessory1.Object, mockAccessory2.Object };

            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor1.Object, accessories);

            //Act
            item.RemoveAccessory(mockAccessory1.Object);

            //Assert
            item.Accessories.Should().HaveCount(c => c == 1);
        }

        [Fact]
        public void RemovingAccessory_InvalidArguments_RaisesException()
        {
            //Arrange
            DateTime dateTime = DateTime.Now;
            var mockVendor1 = new Mock<IVendor>();

            var mockAccessory1 = new Mock<IAccessory>();
            var mockAccessory2 = new Mock<IAccessory>();
            List<IAccessory> accessories = new List<IAccessory>() { mockAccessory1.Object, mockAccessory2.Object};

            var item = new Item("PC", dateTime, 1.5m, "In the living room", mockVendor1.Object, accessories);
            Action addNullAccessory = () => item.RemoveAccessory(null);

            //Act & Assert
            addNullAccessory.Should().Throw<ArgumentNullException>();
        }
    }
}
