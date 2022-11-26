namespace Ecommerce.API.Configurations.Notifications
{
    public interface INotifier
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void AddNotification(Notification notification);
    }
}
