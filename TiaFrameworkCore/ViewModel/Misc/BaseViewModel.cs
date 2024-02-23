using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkCore.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {

        protected INavigationService NavigationService { get; }
        protected IMessageService MessageService { get; }

        [ObservableProperty]
        string _Title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool _IsBusy;
        public bool IsNotBusy => !IsBusy;

        public virtual void OnMessageChanged() { }

        #region ctr

        public BaseViewModel(ICoreServices coreServices)
        {
            NavigationService = coreServices.NavigationService;
            MessageService = coreServices.MessageService;

        }
        #endregion

    }
}