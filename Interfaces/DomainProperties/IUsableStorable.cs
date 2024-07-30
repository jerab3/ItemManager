using Interfaces.Location;

namespace Interfaces.DomainProperties
{
    /// <summary>
    /// Defines an interface for classes that can be stored in a <see cref="IStorageLocation"/>
    /// and can also be actively used. Provides properties and methods for managing usage state
    /// and describing usage details.
    /// </summary>
    public interface IUsableStorable : IStorable
    {
        bool IsBeingUsed { get; }
        string? UsageDescription { get; set; }

        void StartUsing(string usageDescription);
        void StopUsing(IStorageLocation storageLocation);

    }
}
