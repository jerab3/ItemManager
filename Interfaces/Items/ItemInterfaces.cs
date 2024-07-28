using Interfaces.Accessories;
using Interfaces.PurchaseLocations;
using Interfaces.StorageLocations;

namespace Interfaces.Items
{
    public interface IItem
    {
        int Id { get; }
        string ItemName { get; set; }
        DateTime PurchaseDate { get; }
        IPurchaseLocation PurchaseLocation { get; }
        decimal Cost { get; }
        List<IAccessory>? Accessories { get; }
    }
}
