﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Shared._21_Command;

namespace EasyCheckIoCore.ViewModel
{
    public partial class MainViewModel: BaseViewModel
    {

        #region Properties

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string description;

        #endregion

        #region ctr
        public MainViewModel(ICoreServices coreServices) : base(coreServices)
        {
        }
        #endregion

        #region Method

        [RelayCommand]
        public async Task AddDevice()
        {
            await NavigationService.NavigateToHwDevicesView();
        }

        #endregion
    }
}

