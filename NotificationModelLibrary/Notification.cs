namespace NotificationModelLibrary
{
    public class Notification
    {
        public string Message  { get; set; } = string.Empty;
        public DateTime SentDate { get; set; }

        public Notification() { }

        public Notification(string message)
        {
            Message  = message;
            SentDate = DateTime.Now;
        }

        public override string ToString() =>
            $"Message : {Message}\nSent On : {SentDate:yyyy-MM-dd HH:mm:ss}";
    }
}