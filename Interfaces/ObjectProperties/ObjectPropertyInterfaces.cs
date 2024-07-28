
using Interfaces.Items;
using Interfaces.StorageLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.ObjectProperties
{
    public interface IHasWarranty
    {
        DateTime WarrantyEndDate { get; set; }

        bool IsWarrantyStillValid();
    }
    public interface IUsable
    {
        bool IsBeingUsed { get; }
        string? UsageDescription { get; set; }

        void StartUsing(string usageDescription);
        void StopUsing(IStorageLocation storageLocation);
    }
    public interface IStoreable
    {
        IStorageLocation? StorageLocation { get; set; }
    }
}
