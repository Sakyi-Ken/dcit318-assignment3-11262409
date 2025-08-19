namespace assignment3.WarehouseInventory.Models
{
  public class ElectronicItem : IInventoryItem
  {
    public int Id { get; }
    public string Name { get; }
    public int Quantity { get; }
    public string Brand { get; }
    public int WarrantyMonths { get; }

    public ElectronicItem(int id, string name, int quantity, string brand, int warrantyMonths)
    {
      Id = id;
      Name = name;
      Quantity = quantity;
      Brand = brand;
      WarrantyMonths = warrantyMonths;
    }

    public override string ToString()
    {
      return $"[Electronic] ID: {Id}, Name: {Name}, Quantity: {Quantity}, Brand: {Brand}, Warranty: {WarrantyMonths} months";
    }
  }
}