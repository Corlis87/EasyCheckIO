using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Siemens._03_DataBlock;

namespace TiaFrameworkCore.ViewModel
{
    public partial class SiemensNetConfigViewModel : BaseViewModel
    {
        private readonly IS7Lgc _S7Lgc;

        [ObservableProperty]
        private string _Name;
        [ObservableProperty]
        private string _Address;
        [ObservableProperty]
        private int _Slot;
        [ObservableProperty]
        private int _Rack;



        public SiemensNetConfigViewModel(ICoreServices coreServices, IS7Lgc s7Lgc) : base(coreServices)
        {
            _S7Lgc = s7Lgc;
            _Address = _S7Lgc.DB.NetConfig.Address;
            _Slot = _S7Lgc.DB.NetConfig.Slot;
            _Rack=_S7Lgc.DB.NetConfig.Rack;    
      
        }

        [RelayCommand]

        public void Save()
        {
            _S7Lgc.DB.NetConfig = new S7NetConfig { Address = Address, Slot = Slot, Rack = Rack };
            MessageService.DisplayAlert("Message", "Saved");
        }
    }

}