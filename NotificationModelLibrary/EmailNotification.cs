namespace NotificationModelLibrary
{
    public class EmailNotification : Notification
    {
        public string ToEmail { get; set; } = string.Empty;

        public EmailNotification(string message, string toEmail) : base(message)
        {
            ToEmail = toEmail;
        }

        public override string ToString() =>
            $"[EMAIL NOTIFICATION]\nTo      : {ToEmail}\n{base.ToString()}";
    }
}