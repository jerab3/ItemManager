using Interfaces.PurchaseLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.PurchaseLocations
{
    /// <summary>
    /// <see cref="PurchaseLocation"/> serves as a template for derived classes. 
    /// </summary>
    public abstract class PurchaseLocation : IPurchaseLocation
    {
        public int Id { get; }
        public string StoreName { get; set; }

        protected PurchaseLocation(int id, string storeName) 
        {
            if (string.IsNullOrWhiteSpace(storeName))
                throw new ArgumentException(nameof(storeName), "Cannot be null, empty or contain only white spaces");

            this.Id = id;
            this.StoreName = storeName;
        }
    }
    /// <summary>
    /// <see cref="Eshop"/> represents an e-shop. For example: Amazon.
    /// </summary>
    public class Eshop : PurchaseLocation, IEshop
    {
        public string WebAddress { set; get; }

        public Eshop(int id, string storeName, string webAddress)
            :base(id, storeName)
        {
            if (string.IsNullOrWhiteSpace(webAddress))
                throw new ArgumentException(nameof(webAddress), "Cannot be null, empty or contain only white spaces");

            this.WebAddress = webAddress;
        }

        public bool IsWebAddressValid()
        {
            return Uri.IsWellFormedUriString(WebAddress, UriKind.Absolute);
        }
    }
    /// <summary>
    /// <see cref="PhysicalStore"/> represents a physical store. For example: Wallmart.
    /// </summary>
    public class PhysicalStore : PurchaseLocation, IPhysicalStore
    {
        public string Address { get; set; }
        public string City { get; set; }

        public PhysicalStore(int id, string storeName, string address, string city)
            :base (id, storeName)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(nameof(address), "Cannot be null, empty or contain only white spaces");

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException(nameof(city), "Cannot be null, empty or contain only white spaces");

            this.Address = address;
            this.City = city;
        }
    }
}
