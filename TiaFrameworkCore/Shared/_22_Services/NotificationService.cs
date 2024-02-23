using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._23_Store;

namespace TiaFrameworkCore.Shared._22_Services
{
    public class NotificationService : INotificationService
    {
        private NotificationStore _notificationsStore;

        public NotificationService(NotificationStore notificationstore)
        {
            _notificationsStore = notificationstore;
        }

        public void UpdateMessage(string message, bool isError)
        {
            _notificationsStore.Message = message;
            _notificationsStore.IsMessageError = isError;
        }
    }
}
