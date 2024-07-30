using Interfaces.DomainProperties;

namespace Domains.AbstractDomains
{
    /// <summary>
    /// Provides a base class for objects that can be identified by an ID and a name.
    /// </summary>
    public class IdentifiableObject : IIdentifiable
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name), "Cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(Name), "Cannot be null, empty or contain only white spaces");
                }

                name = value;
            }
        }

        protected IdentifiableObject(string name) 
        {
            this.Name = name;
        }

    }
}
