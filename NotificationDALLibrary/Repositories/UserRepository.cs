using NotificationDALLibrary.Interfaces;
using NotificationModelLibrary;

namespace NotificationDALLibrary.Repositories
{
    public class UserRepository : AbstractRepository<string, User>
    {
        public UserRepository()
        {
            _items = new Dictionary<string, User>(StringComparer.OrdinalIgnoreCase);
        }

        public User this[string name]
        {
            get => _items[name];
            set => _items[name] = value;
        }

        public override User Create(User item)
        {
            _items.Add(item.Name, item);
            return item;
        }
    }
}