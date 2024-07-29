using Interfaces.DomainProperties;

namespace Domains.AbstractDomains
{
    /// <summary>
    /// Provides a base class for objects that can be identified by an ID and a name.
    /// </summary>
    public abstract class IdentifiableObject : IIdentifiable
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        protected IdentifiableObject(int id, string name) 
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name), "Cannot be null");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name), "Cannot be empty or contain only white spaces");

            this.Id = id;
            this.Name = name;
        }
    }
}
