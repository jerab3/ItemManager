using Interfaces.PurchaseLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.PurchaseLocations
{
    public abstract class PurchaseLocation(int id, string storeName) : IPurchaseLocation
    {
        public int Id { get; } = id;
        public string StoreName { get; set; } = storeName;
    }
    public class Eshop(int id, string storeName, string webAdress) : PurchaseLocation(id, storeName), IEshop
    {
        public string WebAddress { set; get; } = webAdress;

        public bool IsWebAddressValid()
        {
            return Uri.IsWellFormedUriString(WebAddress, UriKind.Absolute);
        }
    }

    public class PhysicalStore(int id, string storeName, string adress, string city) : PurchaseLocation(id, storeName), IPhysicalStore
    {
        public string Address { get; set; } = adress;
        public string City { get; set; } = city;
    }
}
