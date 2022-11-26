namespace Ecommerce.API.Configurations.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }
    }
}
