using Interfaces.Accessories;
using Interfaces.PurchaseLocations;
using Interfaces.StorageLocations;

namespace Interfaces.Items
{
    public interface IItem
    {
        int Id { get; }
        string Name { get; set; }
        DateTime PurchaseDate { get; }
        IPurchaseLocation PurchaseLocation { get; }
        decimal Cost { get; }
        List<IAccessory>? Accessories { get; }
        IStorageLocation? StorageLocation { get; set; }
    }

    public interface IWarrantyItem : IItem
    {
        DateTime WarrantyEndDate { get; set; }

        bool IsWarrantyStillValid();
    }
}
