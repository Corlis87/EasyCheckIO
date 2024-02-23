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
    public partial class Formulas_p200_InverterViewModel : BaseViewModel
    {

        #region Field

        private const double PercentMaximumCurrent = 1.2;
        private const double PercentMaximumStartCurrent = 1.5;

        #endregion

        #region Properties

        [ObservableProperty]
        private double _Current;
        [ObservableProperty]
        private double _Voltage;
        [ObservableProperty]
        private double _Frequency;
        [ObservableProperty]
        private double _Rpm;
        [ObservableProperty]
        private double _Power;
        [ObservableProperty]
        private double _Cosfi;
        [ObservableProperty]
        private double _MaximumFrequency;
        [ObservableProperty]
        private double _MaximumStartCurrent;
        [ObservableProperty]
        private double _MaximumCurrent;
        [ObservableProperty]
        private double _MaximumSpeed;

        #endregion

        public Formulas_p200_InverterViewModel(ICoreServices coreServices) : base(coreServices)
        {

        }

        [RelayCommand]
        public void Calculate()
        {
            MaximumCurrent= Current * PercentMaximumCurrent;
            MaximumStartCurrent = Current * PercentMaximumStartCurrent;
            MaximumSpeed = MaximumFrequency / Frequency * Rpm;
        }

    }
}
