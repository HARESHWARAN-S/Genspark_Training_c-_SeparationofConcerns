using NotificationModelLibrary;

namespace NotificationDALLibrary.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        T Create(T item);
        T? Get(K key);
        List<T>? GetAll();
        T? Update(K key, T item);
        T? Delete(K key);
    }
}