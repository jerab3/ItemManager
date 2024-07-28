using Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DataStorage
{
    public interface IStorage
    {
        void AddItem(IItem item);
        void EditItem(int itemToEditId, IItem editedItem);
        void RemoveItem(int itemId);
        List<IItem> LoadItems();
    }
}
