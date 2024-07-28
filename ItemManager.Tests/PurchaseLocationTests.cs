using Xunit;
using Objects.PurchaseLocations;

namespace ItemManager.Tests
{
    public class PurchaseLocationTests
    {
        #region Eshop
        [Fact]
        public void Eshop_IsWebAddressValid_CorrectInput_Test()
        {
            var eshop = new Eshop(0, "Alza", "https://www.alza.cz");

            var result = eshop.IsWebAddressValid();

            Assert.True(result);
        }

        [Fact]
        public void Eshop_IsWebAddressValid_IncorrectInput_Test()
        {
            var eshop = new Eshop(0, "Alza", "www.alza.cz");

            var result = eshop.IsWebAddressValid();

            Assert.False(result);
        }

        [Fact]
        public void Eshop_Constructor_Values_Test()
        {
            var eshop = new Eshop(0, "Alza", "https://www.alza.cz");

            Assert.Equal(0, eshop.Id);
            Assert.Equal("Alza", eshop.StoreName);
            Assert.Equal("https://www.alza.cz", eshop.WebAddress);
        }

        [Fact]
        public void Eshop_Constructor_Exceptions_Test()
        {
            Assert.Throws<ArgumentException>(() => new Eshop(0, null, "www.alza.cz"));
            Assert.Throws<ArgumentException>(() => new Eshop(0, "Alza", null));
            Assert.Throws<ArgumentException>(() => new Eshop(0, "Alza", ""));
            Assert.Throws<ArgumentException>(() => new Eshop(0, null, null));
            Assert.Throws<ArgumentException>(() => new Eshop(0, "  ", "  "));
        }
        #endregion
        #region PhysicalStore
        [Fact]
        public void PhysicalStore_Constructor_Values_Test()
        {
            var physicalStore = new PhysicalStore(0, "CZC.CZ", "Vodni 123", "Brno");

            Assert.Equal(0, physicalStore.Id);
            Assert.Equal("CZC.CZ", physicalStore.StoreName);
            Assert.Equal("Vodni 123", physicalStore.Address);
            Assert.Equal("Brno", physicalStore.City);
        }

        [Fact]
        public void PhysicalStore_Constructor_Exceptions_Test()
        {
            Assert.Throws<ArgumentException>(() => new PhysicalStore(0, null, "Kamnarska 256", "Brno"));
            Assert.Throws<ArgumentException>(() => new PhysicalStore(0, "Alza", null, "Brno"));
            Assert.Throws<ArgumentException>(() => new PhysicalStore(0, "Alza", "Kamnarska 256", null));

            Assert.Throws<ArgumentException>(() => new PhysicalStore(0, "", "", ""));
            Assert.Throws<ArgumentException>(() => new PhysicalStore(0, " ", " ", " "));
            Assert.Throws<ArgumentException>(() => new PhysicalStore(0, null, null, null));
        }
        #endregion
    }
}
