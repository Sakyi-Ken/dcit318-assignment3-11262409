using System.Text.Json;
using assignment3.InventorySystem.Interfaces;

namespace assignment3.InventorySystem.Logger
{
  public class InventoryLogger<T> where T : IInventoryEntity
  {
    private readonly List<T> _log = new();
    private readonly string _filePath;

    public InventoryLogger(string filePath)
    {
      _filePath = filePath;
    }

    public void Add(T item)
    {
      _log.Add(item);
    }

    public List<T> GetAll()
    {
      return new List<T>(_log);
    }

    public void SaveToFile()
    {
      try
      {
        string json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
        Console.WriteLine($"Data saved to {_filePath}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error saving to file: {ex.Message}");
      }
    }

    public void LoadFromFile()
    {
      try
      {
        if (!File.Exists(_filePath))
        {
          Console.WriteLine("File not found. Starting with an empty log.");
          return;
        }

        string json = File.ReadAllText(_filePath);
        var items = JsonSerializer.Deserialize<List<T>>(json);

        if (items != null)
        {
          _log.Clear();
          _log.AddRange(items);
        }

        Console.WriteLine("Data loaded from file.");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error loading from file: {ex.Message}");
      }
    }
  }
}