using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.ViewModel
{
    public partial class MessageNotifyViewModel : ObservableObject
    {
        #region Property

        #region IsError
        [ObservableProperty]
        bool _IsError;
        #endregion

        #region Message
        [ObservableProperty]
        string _Message;

        #endregion

        #region IsVisible
        [ObservableProperty]
        private bool _IsVisible;
        #endregion

        #endregion

        #region ctr

        public MessageNotifyViewModel()
        {
            IsVisible = false;
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

        #region UpdateMessage


        public void UpdateMessage(string message, bool isError)
        {
            IsVisible = true;
            Message = message;
            IsError = isError;
        }
        #endregion

        #endregion
    }
}
