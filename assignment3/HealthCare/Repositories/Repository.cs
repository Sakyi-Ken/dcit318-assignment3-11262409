using System.Collections.Generic;
using System.Linq;

namespace Assignment3.Repositories
{
  public class Repository<T>
  {
    private readonly List<T> items = new List<T>();

    public void Add(T item) => items.Add(item);
    public List<T> GetAll() => items;
    public T? GetById(Func<T, bool> predicate) => items.FirstOrDefault(predicate);
    public bool Remove(Func<T, bool> predicate)
    {
      var item = items.FirstOrDefault(predicate);
      if (item != null)
      {
        items.Remove(item);
        return true;
      }
      return false;
    }
  }
}