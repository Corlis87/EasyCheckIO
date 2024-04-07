using AsyncAwaitBestPractices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Program.Extensions;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._06_Enum;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._23_Store;
using TiaFrameworkCore.Shared._24_Messenger;
using TiaFrameworkCore.Shared._80_Util;
using TiaFrameworkCore.Siemens._13_Helper;
using TiaFrameworkCore.Siemens._30_Lgc;

namespace TiaFrameworkCore.ViewModel
{
    public partial class Siemens_p400_CompileViewModel : BaseViewModel
    {
        #region Field

        private readonly IS7Lgc _S7Lgc;
        private readonly ICoreServices _CoreServices;
        private IInterrupt InterruptRefresh;

        #endregion

        #region Properties

        #region Tags

        public IEnumerable<t_S7TagViewModel> Tags => _S7Lgc.ViewValue.Tags;

        #endregion

        #region ConnectionStatus
        [ObservableProperty]
        int _ConnectionStatus;

        #endregion

        #region IsNotConnected

        [ObservableProperty]
        bool _IsNotConnected = true;

        #endregion

        #region NotificationViewModel

        private t_NotificationViewModel _notificationVM;

        public t_NotificationViewModel NotificationViewModel
        {
            get { return _notificationVM; }
            set
            {
                SetProperty(ref _notificationVM, value);
            }
        }
        #endregion

        #endregion

        #region ctr
        public Siemens_p400_CompileViewModel(ICoreServices coreServices, IS7Lgc s7Lgc, NotificationStore notificationStore) : base(coreServices)
        {
            NotificationViewModel = new t_NotificationViewModel(notificationStore);
            _S7Lgc = s7Lgc;
            _CoreServices = coreServices;
            //  InterruptRefresh = InterruptManager.Initialize(1000, false, 0, RefreshUI);
            //  InterruptRefresh.Restart();
        }

        #endregion

        #region Method

        #region Compile

        [RelayCommand]
        public async Task Compile()
        {
            var result = _S7Lgc.CompileS7Tags();
            await MessageService.DisplayAlert("Compile", result.Message);
        }
        #endregion

        #region Online
        [RelayCommand]
        public async Task Online()
        {
            OperationResult result = new OperationResult();
            ConnectionStatus = 1;
            await Task.Run(() =>
            {
                result = _S7Lgc.Connect(_S7Lgc.DB.NetConfig);
            });

            if (result.IsSuccess)
            {
                await MessageService.DisplayAlert("Message", "IP: " + _S7Lgc.DB.NetConfig.Address + " Connection Success");
                IsNotConnected = false;
                ConnectionStatus = 2;
            }
            else
            {
                await MessageService.DisplayAlert("Message", "IP: " + _S7Lgc.DB.NetConfig.Address + " Connection Failed");
                IsNotConnected = true;
                ConnectionStatus = 0;
            }


        }
        #endregion

        #region Offline
        [RelayCommand]
        public void Offline()
        {
            var result = _S7Lgc.Disconnect();
            if (result.IsSuccess)
            {
                MessageService.DisplayAlert("Message", "Disconnected from PLC");
                ConnectionStatus = 0;
                IsNotConnected = true;
            }
            else
                MessageService.DisplayAlert("Message", " Fail to disconnected from PLC");


        }
        #endregion

        #region OpenSavePopout
        [RelayCommand]
        public async Task OpenSaveTagsViewModel()
        {
            await NavigationService.NavigateToSaveTags(Tags);
        }
        #endregion

        #region OpenLoadTagsViewModel

        [RelayCommand]
        public async Task OpenLoadTagsViewModel()
        {
            await NavigationService.NavigateToLoadFileView();
        }

        #endregion

        #region SearchTag
        [RelayCommand]
        public async Task SearchTag()
        {
            await NavigationService.NavigateToModuleSearchTagView();
        }

        #endregion

        #endregion
    }
}
