using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkCore.ViewModel
{
    public partial class FormViewModel : BaseViewModel
    {

        #region ctr
        public FormViewModel(ICoreServices coreServices) : base(coreServices)
        {

        }
        #endregion

        #region Method
        [RelayCommand]       
        public async Task ProportionalView()
        {
            await NavigationService.NavigateToProportion();
        }

        [RelayCommand]
        public async Task InverterView()
        {
            await NavigationService.NavigateToAbb();
        }
#endregion

    }
}
