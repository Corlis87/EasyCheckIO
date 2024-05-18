using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Shared._23_Store;

namespace EasyCheckIoCore.Shared._22_Services
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
