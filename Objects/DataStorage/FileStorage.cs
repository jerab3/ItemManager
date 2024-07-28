using Interfaces.DataStorage;
using Interfaces.Items;

namespace Objects.DataStorage
{
    public class FileStorage : IStorage
    {
        public void AddItem(IItem item)
        {
            Console.WriteLine("Saving item into local file storage");
        }

        public void RemoveItem(int itemId)
        {
            Console.WriteLine("Deleting item from local file storage");
        }

        public List<IItem> LoadItems()
        {
            Console.WriteLine("Loading items from local file storage");
            return null;
        }
    }
}
