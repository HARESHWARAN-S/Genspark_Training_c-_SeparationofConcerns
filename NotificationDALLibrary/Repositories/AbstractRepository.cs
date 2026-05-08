using NotificationDALLibrary.Interfaces;

namespace NotificationDALLibrary.Repositories
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T> where T : class
    {
        protected Dictionary<K, T> _items = new();

        public abstract T Create(T item);

        public T? Get(K key)
        {
            if (_items.ContainsKey(key))
                return _items[key];
            return null;
        }

        public List<T>? GetAll()
        {
            if (_items.Count == 0) return null;
            return _items.Values.ToList();
        }

        public T? Update(K key, T item)
        {
            if (!_items.ContainsKey(key)) return null;
            _items[key] = item;
            return item;
        }

        public T? Delete(K key)
        {
            if (!_items.ContainsKey(key)) return null;
            var item = _items[key];
            _items.Remove(key);
            return item;
        }
    }
}