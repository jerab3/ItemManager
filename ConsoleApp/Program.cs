using System;
using System.Collections.Generic;
using Interfaces.Items;
using Interfaces.PurchaseLocations;
using Interfaces.StorageLocations;
using Objects.DataStorage;
using Objects.Items;
using Objects.PurchaseLocations;
using Objects.StorageLocations;

class Program
{
    static void Main(string[] args)
    {
        var storage = StorageFactory.GetStorage(StorageType.File);

        var items = new List<IItem>();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Item Management System");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. List Items");
            Console.WriteLine("3. List Items With Warranty");
            Console.WriteLine("4. Edit Item");
            Console.WriteLine("5. Delete Item");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddItem(items);
                    break;
                case "2":
                    ListItems(items);
                    break;
                case "3":
                    ListItemsWithWarranty(items);
                    break;
                case "4":
                    EditItem(items);
                    break;
                case "5":
                    DeleteItem(items);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AddItem(List<IItem> items)
    {
        Console.Clear();
        Console.WriteLine("Add Item");

        Console.Write("Enter item name: ");
        string name = Console.ReadLine().Trim();

        Console.Write("Enter purchase date (yyyy-mm-dd): ");
        DateTime purchaseDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter cost: ");
        decimal cost = decimal.Parse(Console.ReadLine());

        Console.Write("Enter store name: ");
        string storeName = Console.ReadLine().Trim();

        Console.Write("Enter store address: ");
        string storeAddress = Console.ReadLine().Trim();

        Console.Write("Enter store city: ");
        string storeCity = Console.ReadLine().Trim();

        IPurchaseLocation purchaseLocation = new PhysicalStore(items.Count, storeName, storeAddress, storeCity);

        Console.Write("Has your item warranty? (Y/N): ");
        string hasItemWarranty = Console.ReadLine().Trim();

        IItem item = null;

        if (hasItemWarranty == "Y")
        {
            Console.Write("Enter when you warranty ends (yyyy-mm-dd): ");
            DateTime warrantyDate = DateTime.Parse(Console.ReadLine());

            item = new WarrantyItem(items.Count, name, purchaseDate, purchaseLocation, cost, null, "In use", warrantyDate);
        }
        else
        {
            item = new Item(items.Count, name, purchaseDate, purchaseLocation, cost, null, "In use");
        }

        items.Add(item);


        Console.WriteLine("Item added successfully. Press any key to continue.");
        Console.ReadKey();
    }

    static void ListItems(List<IItem> items)
    {
        Console.Clear();
        Console.WriteLine("List of Items");

        foreach (var item in items)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.ItemName}, Purchase Date: {item.PurchaseDate.ToShortDateString()}, Cost: {item.Cost}, Store: {item.PurchaseLocation.StoreName}");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    static void ListItemsWithWarranty(List<IItem> items)
    {
        Console.Clear();
        Console.WriteLine("List of Items with warranty");

        var warrantyItems = items.OfType<WarrantyItem>().ToList();

        foreach (var item in warrantyItems)
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.ItemName}, Warranty End Date: {item.WarrantyEndDate.ToShortDateString()}, Purchase Date: {item.PurchaseDate.ToShortDateString()}, Cost: {item.Cost}, Store: {item.PurchaseLocation.StoreName}");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    static void EditItem(List<IItem> items)
    {
        Console.Clear();
        Console.WriteLine("Edit Item");

        Console.Write("Enter item ID: ");
        int id = int.Parse(Console.ReadLine());

        var item = items.Find(i => i.Id == id);
        if (item == null)
        {
            Console.WriteLine("Item not found. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter new item name (leave blank to keep current): ");
        string name = Console.ReadLine();

        Console.Write("Enter new cost (leave blank to keep current): ");
        string costStr = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(name) || !string.IsNullOrWhiteSpace(costStr))
        {
            items.Remove(item);

            string newName = string.IsNullOrWhiteSpace(name) ? item.ItemName : name;
            decimal newCost = string.IsNullOrWhiteSpace(costStr) ? item.Cost : decimal.Parse(costStr);

            IItem newItem = new Item(item.Id, newName, item.PurchaseDate, item.PurchaseLocation, newCost, item.Accessories, "In use");
            items.Add(newItem);

            Console.WriteLine("Item updated successfully. Press any key to continue.");
        }
        else
        {
            Console.WriteLine("No changes made. Press any key to continue.");
        }

        Console.ReadKey();
    }

    static void DeleteItem(List<IItem> items)
    {
        Console.Clear();
        Console.WriteLine("Delete Item");

        Console.Write("Enter item ID: ");
        int id = int.Parse(Console.ReadLine());

        var item = items.Find(i => i.Id == id);
        if (item == null)
        {
            Console.WriteLine("Item not found. Press any key to continue.");
            Console.ReadKey();
            return;
        }

        items.Remove(item);

        Console.WriteLine("Item deleted successfully. Press any key to continue.");
        Console.ReadKey();
    }
}
