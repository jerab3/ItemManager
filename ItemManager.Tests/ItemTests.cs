using Xunit;
using Objects.StorageLocations;
using Objects.Items;
using Moq;
using Interfaces.StorageLocations;
using Interfaces.PurchaseLocations;
using Interfaces.Accessories;

namespace ItemManager.Tests
{
    public class ItemTests
    {
        #region Item
        [Fact]
        public void Item_Constructor_Values_Stored_WithoutAccessories_Test()
        {
            var mockPurchaseLocation = new Mock<IPurchaseLocation>();
            var mockStorageLocation = new Mock<IStorageLocation>();
            DateTime dateTime = DateTime.Now;

            var item = new Item(0, "PC", dateTime, mockPurchaseLocation.Object, 150.99M, null, mockStorageLocation.Object);

            Assert.Equal(0, item.Id);
            Assert.Equal("PC", item.ItemName);
            Assert.Equal(dateTime, item.PurchaseDate);
            Assert.Equal(mockPurchaseLocation.Object, item.PurchaseLocation);
            Assert.Equal(150.99M, item.Cost);
            Assert.Null(item.Accessories);
            Assert.Equal(mockStorageLocation.Object, item.StorageLocation);
        }

        [Fact]
        public void Item_Constructor_Values_Used_WithAccessories_Test()
        {
            var mockPurchaseLocation = new Mock<IPurchaseLocation>();
            var mockStorageLocation = new Mock<IStorageLocation>();
            DateTime dateTime = DateTime.Now;

            var mockAccessory1 = new Mock<IAccessory>();
            var mockAccessory2 = new Mock<IAccessory>();
            var mockAccessory3  = new Mock<IAccessory>();

            var mockAccessories = new List<IAccessory> { mockAccessory1.Object, mockAccessory2.Object, mockAccessory3.Object};

            var item = new Item(0, "PC", dateTime, mockPurchaseLocation.Object, 150.99M, mockAccessories, "In living room on table");

            Assert.Equal(0, item.Id);
            Assert.Equal("PC", item.ItemName);
            Assert.Equal(dateTime, item.PurchaseDate);
            Assert.Equal(mockPurchaseLocation.Object, item.PurchaseLocation);
            Assert.Equal(150.99M, item.Cost);
            Assert.Equal(3, item.Accessories.Count);
            Assert.Equal("In living room on table", item.UsageDescription);
        }
        #endregion
        #region WarrantyItem
        [Fact]
        public void WarrantyItem_IsWarrantyStillValid_Test()
        {
            var mockPurchaseLocation = new Mock<IPurchaseLocation>();
            var mockStorageLocation = new Mock<IStorageLocation>();

            DateTime warrantyEndTime = new DateTime(2025, 01, 01);

            var warrantyItem = new WarrantyItem(0, "PC", DateTime.Now, mockPurchaseLocation.Object, 0, null, mockStorageLocation.Object, warrantyEndTime);

            Assert.True(warrantyItem.IsWarrantyStillValid());

            warrantyEndTime = new DateTime(2023, 01, 01);

            warrantyItem = new WarrantyItem(0, "PC", DateTime.Now, mockPurchaseLocation.Object, 0, null, mockStorageLocation.Object, warrantyEndTime);

            Assert.False(warrantyItem.IsWarrantyStillValid());
        }
        #endregion
    }
}
