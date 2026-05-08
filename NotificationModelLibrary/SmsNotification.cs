namespace NotificationModelLibrary
{
    public class SmsNotification : Notification
    {
        public string ToPhone { get; set; } = string.Empty;

        public SmsNotification(string message, string toPhone) : base(message)
        {
            ToPhone = toPhone;
        }

        public override string ToString() =>
            $"[SMS NOTIFICATION]\nTo      : {ToPhone}\n{base.ToString()}";
    }
}