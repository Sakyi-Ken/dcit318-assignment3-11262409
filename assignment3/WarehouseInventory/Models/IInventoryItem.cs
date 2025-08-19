namespace assignment3.WarehouseInventory.Models
{
  public interface IInventoryItem
  {
    int Id { get; }
    string Name { get; }
    int Quantity { get; set; }
  }
}