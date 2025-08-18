using Assignment3.Models;

namespace Assignment3.Repositories
{
  public class Repository<T> where T : IEntity
  {
    // private readonly List<T> _items = new List<T>();
    private readonly Dictionary<int, T> _items = new();

    // public void Add(T item) => items.Add(item);
    public void Add(T item) => _items[item.Id] = item;
    
    // public List<T> GetAll() => items;
    public List<T> GetAll() => _items.Values.ToList();

    // public T? GetById(Func<T, bool> predicate) => items.FirstOrDefault(predicate);
    public T? GetById(int id) => _items.TryGetValue(id, out var item) ? item : default;

    // public bool Remove(Func<T, bool> predicate)
    // {
    //   var item = items.FirstOrDefault(predicate);
    //   if (item != null)
    //   {
    //     items.Remove(item);
    //     return true;
    //   }
    //   return false;
    // }

    public bool Remove(Func<T, bool> predicate)
    {
      var item = _items.Values.FirstOrDefault(predicate);
      if (item != null)
      {
        _items.Remove(item.Id);
        return true;
      }
      return false;
    }
    // public bool Remove(int id) => _items.Remove(id);
  }
}