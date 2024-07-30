using Interfaces.Accessories;
using Interfaces.DomainProperties;

namespace Interfaces.Items
{
    /// <summary>
    /// Defines interface for classes that serve as bought items.
    /// </summary>
    public interface IItem : IIdentifiable, IUsableStorable
    {
        DateTime PurchaseDate { get; set; }
        decimal Cost { get; set; }
        IEnumerable<IAccessory> Accessories { get; }
        
        void AddAccessory();
        void RemoveAccessory();
    }
}
