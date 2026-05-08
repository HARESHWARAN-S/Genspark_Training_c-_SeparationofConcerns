using NotificationModelLibrary;

namespace NotificationBLLibrary.Interfaces
{
    public interface INotificationService
    {
        void AddUser(User user);
        void DeleteUser(string userName);
        void UpdateUser(string userName, User updatedUser);
        void ListUsers();
        void SendEmailNotification(string userName, string message);
        void SendSmsNotification(string userName, string message);
    }
}