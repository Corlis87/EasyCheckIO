using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Siemens._03_DataBlock;
using TiaFrameworkCore.ViewModel;

namespace TiaFrameworkCore.Shared._11_Contracts
{
    public interface INavigationService
    {
        Task NavigateToHwDevicesView();
        Task NavigateToMainView();
        Task NavigateToHwDeviceConfigView();
        Task NavigateToPreviewPushModalAsync();
        Task NavigateToHwDeviceEditView(S7Tag tag);
        Task NavigateToHwDeviceTagsView();
        Task NavigateToHwDeviceEditPlcProfileView();
        Task NavigateToScaling(t_S7TagViewModel s7TagView);
        Task NavigateToConversion(t_S7TagViewModel s7TagView);
        Task NavigateToModuleSearchTagView();
        Task NavigateToProportion();
        Task NavigateToAbb();
        Task NavigateToCompilePageView();
        Task NavigateToSaveTags(IEnumerable<t_S7TagViewModel> s7TagViewModels);
        Task NavigateToLoadFileView();
        Task CloseMopout();
    }
}
