using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._06_Enum;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Siemens._03_DataBlock;

namespace TiaFrameworkCore.ViewModel
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
