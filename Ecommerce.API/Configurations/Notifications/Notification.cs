namespace Ecommerce.API.Configurations.Notifications
{
    public class Notification
    {
        public string Field { get; private set; }
        public string Message { get; private set; }

        public Notification(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}
