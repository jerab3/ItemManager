namespace Interfaces.DomainProperties
{
    /// <summary>
    /// Interface defining warranty-related properties and methods for classes.
    /// </summary>
    public interface IHasWarranty
    {
        DateTime WarrantyEndDate { get; set; }

        bool IsWarrantyStillValid();
    }
}
