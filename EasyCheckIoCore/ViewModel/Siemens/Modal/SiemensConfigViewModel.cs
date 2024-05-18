using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._06_Enum;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Shared._24_Messenger;
using EasyCheckIoCore.Siemens._03_DataBlock;

namespace EasyCheckIoCore.ViewModel
{
    public partial class SiemensConfigViewModel: BaseViewModel

    {
        private readonly IS7Lgc _S7Lgc;

        #region Property

        public S7Tag Tag { get;  }

        #endregion

        public SiemensConfigViewModel(ICoreServices coreServices, IS7Lgc s7Lgc) : base(coreServices)
        {
            _S7Lgc = s7Lgc;
            Tag = new S7Tag();
        
        }


        #region Commands

        [RelayCommand]
        public async Task Save()
        {
            _S7Lgc.Param.Tags.Add(Tag);
            WeakReferenceMessenger.Default.Send(new AddItemMessage(Tag));
        await NavigationService.NavigateToPreviewPushModalAsync();
        }

        [RelayCommand]
        public async Task GoBack()
        {
          await  NavigationService.NavigateToPreviewPushModalAsync();
        }

        #endregion
    }
}
