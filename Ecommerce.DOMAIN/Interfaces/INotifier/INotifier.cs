using Ecommerce.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DOMAIN.Interfaces.INotifier
{
    public interface INotifier
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void AddNotification(Notification notification);
    }
}
