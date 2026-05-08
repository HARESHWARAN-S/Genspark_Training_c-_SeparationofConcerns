using NotificationBLLibrary.Interfaces;
using NotificationBLLibrary.Services;
using NotificationModelLibrary;

namespace NotificationFEApplication
{
    public class Program
    {
        // Interface type — any INotificationService implementation can be swapped in
        INotificationService notificationService;

        public Program()
        {
            notificationService = new NotificationService();
        }

        void Run()
        {
            int choice;
            do
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine("    ABC Company Notifier");
                Console.WriteLine("==============================");
                Console.WriteLine(" 1. Add User");
                Console.WriteLine(" 2. Delete User");
                Console.WriteLine(" 3. Update User");
                Console.WriteLine(" 4. Show All Users");
                Console.WriteLine(" 5. Send SMS Notification");
                Console.WriteLine(" 6. Send Email Notification");
                Console.WriteLine(" 7. Exit");
                Console.Write("Enter your choice: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        notificationService.AddUser(TakeUserDetails());
                        break;

                    case 2:
                        Console.Write("Enter the name of the user to delete: ");
                        string delName = Console.ReadLine() ?? "";
                        notificationService.DeleteUser(delName);
                        break;

                    case 3:
                        Console.Write("Enter the name of the user to update: ");
                        string oldName = Console.ReadLine() ?? "";
                        Console.WriteLine("Enter new details:");
                        User updated = TakeUserDetails();
                        notificationService.UpdateUser(oldName, updated);
                        break;

                    case 4:
                        notificationService.ListUsers();
                        break;

                    case 5:
                        Console.Write("Enter the user's name: ");
                        string smsName = Console.ReadLine() ?? "";
                        Console.Write("Enter the message   : ");
                        string smsMsg = Console.ReadLine() ?? "";
                        notificationService.SendSmsNotification(smsName, smsMsg);
                        break;

                    case 6:
                        Console.Write("Enter the user's name: ");
                        string emailName = Console.ReadLine() ?? "";
                        Console.Write("Enter the message   : ");
                        string emailMsg = Console.ReadLine() ?? "";
                        notificationService.SendEmailNotification(emailName, emailMsg);
                        break;

                    case 7:
                        Console.WriteLine("\nGoodbye!");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            } while (choice != 7);
        }

        // Mirrors TakeCustomerDetails() from banking app
        public User TakeUserDetails()
        {
            Console.Write("Enter full name    : ");
            string name  = Console.ReadLine() ?? "";
            Console.Write("Enter email address: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Enter phone number : ");
            string phone = Console.ReadLine() ?? "";
            return new User(name, email, phone);
        }

        public static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}