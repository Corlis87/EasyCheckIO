using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._23_Store;

namespace EasyCheckIoCore.ViewModel
{
    public partial class t_NotificationViewModel : ObservableObject
    {
        #region Fields

        private NotificationStore _notificationsStr;

        #endregion

        #region Property

        #region IsError
        public bool IsError
        {
            get { return _notificationsStr.IsMessageError; }
            set { }
        }

        public string Message
        {
            get { return _notificationsStr.Message; }
            set { }
        }
        #endregion

        #region IsVisible
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsError))]
        private bool _IsVisible;
        #endregion


        #endregion

        #region ctr

        public t_NotificationViewModel(NotificationStore notificationstore)
        {
            IsVisible = false;

            _notificationsStr = notificationstore;
            _notificationsStr.StateChanged += _notificationsStore_StateChanged;



        }
        #endregion

        #region Method

        #region HideNotification
        [RelayCommand]
        public void HideNotification()
        {
            IsVisible = false;
        }
        #endregion

        #endregion

        #region Event

        #region NotificationsStore_StateChanged
        private void _notificationsStore_StateChanged()
        {
            IsVisible = false;

            
            OnPropertyChanged(nameof(IsError));
            OnPropertyChanged(nameof(Message));
            IsVisible = true;
        }
        #endregion

        #region NotificationViewModelDestruction
        ~t_NotificationViewModel()
        {
            _notificationsStr.StateChanged -= _notificationsStore_StateChanged;
        }
        #endregion

        #endregion
    }
}
