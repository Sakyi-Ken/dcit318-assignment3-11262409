using assignment3.InventorySystem.Interfaces;
namespace assignment3.InventorySystem.Models
{
  public record InventoryItem( int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity; 
}