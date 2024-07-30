namespace Interfaces.DomainProperties
{
    /// <summary>
    /// Defines basic properties including a unique identifier and a name.
    /// </summary>
    public interface IIdentifiable
    {
        int Id { get; set; }
        string Name { get; set; }

    }
}
