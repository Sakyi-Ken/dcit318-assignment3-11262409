using System;

namespace assignment3.WarehouseInventory.Exceptions
{
  public class InvalidQuantityException : Exception
  {
    public InvalidQuantityException(string message) : base(message) { }
  }
}