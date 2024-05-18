using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._23_Store
{
    public class NotificationStore : ObservableObject
    {
        public event Action StateChanged;


        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                StateChanged?.Invoke();
            }
        }


        private bool _isMessageError;
        public bool IsMessageError
        {
            get { return _isMessageError; }
            set
            {
                _isMessageError = value;
                StateChanged?.Invoke();
            }
        }
    }
}
