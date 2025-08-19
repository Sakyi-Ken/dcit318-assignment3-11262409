using System;

namespace assignment3.WarehouseInventory.Exceptions
{
  public class DuplicateItemException : Exception
  {
    public DuplicateItemException(string message) : base(message) { }
  }
}