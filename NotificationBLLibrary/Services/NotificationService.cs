using NotificationBLLibrary.Interfaces;
using NotificationModelLibrary;
using NotificationDALLibrary.Interfaces;
using NotificationDALLibrary.Repositories;

namespace NotificationBLLibrary.Services
{
    public class NotificationService : INotificationService
    {
        // Uses repository — mirrors how CustomerService used List<Account>
        // but now through a proper repository layer
        private readonly UserRepository _userRepository = new UserRepository();

        // ── CRUD ────────────────────────────────────────────────────────────

        public void AddUser(User user)
        {
            // Use null check directly — avoids operator overload on null
            if (_userRepository.Get(user.Name) != null)
            {
                Console.WriteLine($"\nA user named '{user.Name}' already exists.");
                return;
            }
            _userRepository.Create(user);
            Console.WriteLine($"\nUser '{user.Name}' added successfully.");
        }

        public void DeleteUser(string userName)
        {
            var deleted = _userRepository.Delete(userName);
            if (deleted == null)
            {
                Console.WriteLine($"\nNo user found with the name '{userName}'.");
                return;
            }
            Console.WriteLine($"\nUser '{deleted.Name}' deleted successfully.");
        }

        public void UpdateUser(string userName, User updatedUser)
        {
            var result = _userRepository.Update(userName, updatedUser);
            if (result == null)
            {
                Console.WriteLine($"\nNo user found with the name '{userName}'.");
                return;
            }
            Console.WriteLine($"\nUser '{userName}' updated successfully.");
        }

        public void ListUsers()
        {
            var users = _userRepository.GetAll();
            if (users == null)
            {
                Console.WriteLine("\nNo users registered yet.");
                return;
            }
            Console.WriteLine("\n------- Registered Users -------");
            foreach (var user in users)
            {
                Console.WriteLine(user);
                Console.WriteLine("--------------------------------");
            }
        }

        // ── Notifications ────────────────────────────────────────────────────

        public void SendEmailNotification(string userName, string message)
        {
            User? user = FindUser(userName);
            if (user == null) return;

            // Polymorphism: base reference, child instance — same pattern as banking
            Notification notification = new EmailNotification(message, user.Email);
            Deliver(notification);
        }

        public void SendSmsNotification(string userName, string message)
        {
            User? user = FindUser(userName);
            if (user == null) return;

            Notification notification = new SmsNotification(message, user.Phone);
            Deliver(notification);
        }

        // ── Private helpers ──────────────────────────────────────────────────

        private User? FindUser(string userName)
        {
            // Uses indexer shorthand via repository's Get
            var user = _userRepository.Get(userName);
            if (user == null)
                Console.WriteLine($"\nNo user found with the name '{userName}'.");
            return user;
        }

        private void Deliver(Notification notification)
        {
            Console.WriteLine("\n-------- Notification Sent --------");
            Console.WriteLine(notification);
            Console.WriteLine("-----------------------------------");
        }
    }
}