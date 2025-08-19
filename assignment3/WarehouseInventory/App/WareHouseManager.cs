using assignment3.WarehouseInventory.Models;
using assignment3.WarehouseInventory.Exceptions;
using assignment3.WarehouseInventory.Repositories;

namespace assignment3.WarehouseInventory.App
{
  public class WareHouseManager
  {
    private readonly InventoryRepository<ElectronicItem> _electronics = new InventoryRepository<ElectronicItem>();
    private readonly InventoryRepository<GroceryItem> _groceries = new InventoryRepository<GroceryItem>();

    public void SeedData()
    {
      // Add Electronics
      _electronics.AddItem(new ElectronicItem(1, "Laptop", 5, "Dell", 24));
      _electronics.AddItem(new ElectronicItem(2, "Phone", 10, "Samsung", 12));

      // Add Groceries
      _groceries.AddItem(new GroceryItem(1, "Milk", 20, DateTime.Now.AddDays(7)));
      _groceries.AddItem(new GroceryItem(2, "Bread", 15, DateTime.Now.AddDays(3)));
    }

    public static void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
    {
      foreach (var item in repo.GetAllItems())
      {
        Console.WriteLine(item);
      }
    }

    public static void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
    {
      try
      {
        var item = repo.GetItemById(id);
        repo.UpdateQuantity(id, item.Quantity + quantity);
        Console.WriteLine($"Updated stock for {item.Name}, new quantity: {item.Quantity}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }

    public static void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
    {
      try
      {
        repo.RemoveItem(id);
        Console.WriteLine($"Item with ID {id} removed successfully.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }

    public InventoryRepository<ElectronicItem> ElectronicsRepo => _electronics;
    public InventoryRepository<GroceryItem> GroceriesRepo => _groceries;


    public void Run()
    {
      SeedData();

      Console.WriteLine("=== Grocery Items ===");
      PrintAllItems(GroceriesRepo);

      Console.WriteLine("\n=== Electronic Items ===");
      PrintAllItems(ElectronicsRepo);

      // Trigger exceptions
      Console.WriteLine("\n=== Exception Demonstrations ===");

      try
      {
        // Duplicate item
        ElectronicsRepo.AddItem(new ElectronicItem(1, "Tablet", 3, "Apple", 18));
      }
      catch (DuplicateItemException ex)
      {
        Console.WriteLine($"Caught Exception: {ex.Message}");
      }

      try
      {
        // Non-existent remove
        RemoveItemById(GroceriesRepo, 99);
      }
      catch (ItemNotFoundException ex)
      {
        Console.WriteLine($"Caught Exception: {ex.Message}");
      }

      try
      {
        // Invalid quantity
        ElectronicsRepo.UpdateQuantity(2, -5);
      }
      catch (InvalidQuantityException ex)
      {
        Console.WriteLine($"Caught Exception: {ex.Message}");
      }
    }
  }
}  
