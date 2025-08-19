using assignment3.WarehouseInventory.Models;
using assignment3.WarehouseInventory.Exceptions;

namespace assignment3.WarehouseInventory.Repositories
{
  public class InventoryRepository<T> where T : IInventoryItem
  {
    private readonly Dictionary<int, T> _items = new Dictionary<int, T>();

    public void AddItem(T item)
    {
      if (_items.ContainsKey(item.Id))
        throw new DuplicateItemException($"Item with ID {item.Id} already exists.");

      _items[item.Id] = item;
    }

    public T GetItemById(int id)
    {
      if (!_items.ContainsKey(id))
        throw new ItemNotFoundException($"Item with ID {id} was not found.");

      return _items[id];
    }

    public void RemoveItem(int id)
    {
      if (!_items.Remove(id))
        throw new ItemNotFoundException($"Item with ID {id} was not found.");
    }

    public List<T> GetAllItems()
    {
      return new List<T>(_items.Values);
    }

    public void UpdateQuantity(int id, int newQuantity)
    {
      if (newQuantity < 0)
        throw new InvalidQuantityException("Quantity cannot be negative.");

      // if (!_items.ContainsKey(id))
      //   throw new ItemNotFoundException($"Item with ID {id} was not found.");

      //_items[id].Quantity = newQuantity;
      
      var item = GetItemById(id);
      item.Quantity = newQuantity;
    }
  }
}