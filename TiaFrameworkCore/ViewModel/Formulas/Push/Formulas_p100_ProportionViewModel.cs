using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkCore.ViewModel
{
    public partial class Formulas_p100_ProportionViewModel : BaseViewModel
    {
        [ObservableProperty]
        private double _ValueA;
        [ObservableProperty]
        private double _ValueB;
        [ObservableProperty]
        private double _ValueC;
        [ObservableProperty]
        private double _Result;



        [RelayCommand]
        public void ProportionValueChanged()
        {
            if (ValueA != 0)
                Result = ValueB / ValueA * ValueC;
        }
        public Formulas_p100_ProportionViewModel(ICoreServices coreServices) : base(coreServices)
        {

        }
    }
}
