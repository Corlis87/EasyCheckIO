using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._06_Enum;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Shared._24_Messenger;
using EasyCheckIoCore.Siemens._03_DataBlock;
using EasyCheckIoCore.Siemens._30_Lgc;

namespace EasyCheckIoCore.ViewModel
{
    public partial class SiemensEditorViewModel : BaseViewModel
    {

        #region Property

        private readonly IS7Lgc _S7Lgc;

        #endregion

        public S7Tag Tag { get; set; }

        #region ctr
        public SiemensEditorViewModel(ICoreServices coreServices,S7Tag tag,IS7Lgc s7Lgc) : base(coreServices)
        {
            Tag = tag;  

            _S7Lgc = s7Lgc;
        }
        #endregion

        [RelayCommand]
        public async Task Edit()
        {
            WeakReferenceMessenger.Default.Send(new AddItemMessage(Tag));
            await NavigationService.NavigateToPreviewPushModalAsync();
        }

    }
}
