using System;

namespace assignment3.WarehouseInventory.Exceptions
{
  public class ItemNotFoundException : Exception
  {
    public ItemNotFoundException(string message) : base(message) { }
  }
}