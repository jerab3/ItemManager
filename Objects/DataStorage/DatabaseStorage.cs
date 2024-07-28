using Interfaces.DataStorage;
using Interfaces.Items;

namespace Objects.DataStorage
{
    public class DatabaseStorage : IStorage
    {
        public void AddItem(IItem item)
        {
            Console.WriteLine("Saving item into database");
        }

        public void RemoveItem(int itemId)
        {
            Console.WriteLine("Deleting item from database");
        }

        public List<IItem> LoadItems()
        {
            Console.WriteLine("Loading items from database");
            return null;
        }
    }
}
