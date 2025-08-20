using assignment3.InventorySystem.Logger;
using assignment3.InventorySystem.Models;

namespace assignment3.InventorySystem.App
{
  public class InventoryApp
  {
    private readonly InventoryLogger<InventoryItem> _logger;

    public InventoryApp(string filePath)
    {
      _logger = new InventoryLogger<InventoryItem>(filePath);
    }

    public void SeedSampleData()
    {
      _logger.Add(new InventoryItem(1, "Laptop", 5, DateTime.Now));
      _logger.Add(new InventoryItem(2, "Smartphone", 10, DateTime.Now));
      _logger.Add(new InventoryItem(3, "Tablet", 7, DateTime.Now));
      _logger.Add(new InventoryItem(4, "Monitor", 3, DateTime.Now));
    }

    public void SaveData()
    {
      _logger.SaveToFile();
    }

    public void LoadData()
    {
      _logger.LoadFromFile();
    }

    public void PrintAllItems()
    {
      var items = _logger.GetAll();
      foreach (var item in items)
      {
        Console.WriteLine($"{item.Name} (ID: {item.Id}) - Qty: {item.Quantity}, Added: {item.DateAdded}");
      }
    }

    public void Run()
    {
      // string filePath = "inventory.json"; // persisted as JSON
      // var app = new InventoryApp(filePath);

      // Step 1: Seed Data
      SeedSampleData();

      // Step 2: Save to File
      SaveData();

      // Step 3: Simulate new session (clear memory by creating a new app)
      //var newApp = new InventoryApp(filePath);

      // Step 4: Load from File
      LoadData();

      // Step 5: Print Items
      PrintAllItems();
    }
  }
}