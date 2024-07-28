namespace Interfaces.PurchaseLocations
{
    public interface IPurchaseLocation
    {
        int Id { get; }
        string StoreName { get; set; }
    }
    public interface IEshop : IPurchaseLocation
    {
        string WebAddress { get; set; }

        bool IsWebAddressValid();
    }
    public interface IPhysicalStore : IPurchaseLocation
    {
        string Address { get; set; }
        string City { get; set; }
    }
}
