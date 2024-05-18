using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._06_Enum;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Siemens._03_DataBlock;

namespace EasyCheckIoCore.ViewModel
{
    public partial class t_PartialModuleViewModel:BaseViewModel
    {

        public S7Tag Tag { get; set; }

        public t_PartialModuleViewModel(ICoreServices coreServices,S7Tag tag) : base(coreServices)
        {
            Tag = tag;
        }

        [RelayCommand]

        public async Task Edit()
        {            
            await NavigationService.NavigateToHwDeviceEditView(Tag);
        }
     


    }
}
