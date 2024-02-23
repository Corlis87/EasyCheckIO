using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._22_Services;
using TiaFrameworkCore.Siemens._03_DataBlock;
using TiaFrameworkCore.ViewModel;
using TiaFrameworkCore.ViewModel.Siemens.Template;
using TiaFrameworkUI.View;
using TiaFrameworkUI.View.Form;

namespace TiaFrameworkUI.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToHwDevicesView()
        {
            await Shell.Current.GoToAsync(nameof(_10_SiemensView));
        }

        public async Task NavigateToMainView()
        {
            await Shell.Current.GoToAsync(nameof(_00_MainView));
        }

        public async Task NavigateToHwDeviceConfigView()
        {
            await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<Siemens_m100_ConfigView>());
            //  await Shell.Current.GoToAsync("//" + nameof(HwDeviceConfigView));
        }

        public async Task NavigateToHwDeviceEditView(S7Tag tag)
        {
            await Shell.Current.Navigation.PushModalAsync(new Siemens_m200_EditorView(new Siemens_m200_EditorViewModel(Shell.Current.Handler.MauiContext.Services.GetService<ICoreServices>(),tag, Shell.Current.Handler.MauiContext.Services.GetService<IS7Lgc>())));
            //  await Shell.Current.GoToAsync("//" + nameof(HwDeviceConfigView));
        }

        public async Task NavigateToHwDeviceTagsView()
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await Shell.Current.GoToAsync(nameof(Siemens_p400_CompileView));
        }

        public async Task NavigateToModuleSearchTagView()
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await Shell.Current.GoToAsync(nameof(Siemens_p410_SearchView));
        }

        public async Task NavigateToLoadFileView()
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await Shell.Current.GoToAsync(nameof(Siemens_p420_LoadTagsView));
        }

        public async Task NavigateToCompilePageView()
        {
            await Shell.Current.GoToAsync(nameof(Siemens_p400_CompileView));
        }
        public async Task NavigateToHwDeviceEditPlcProfileView()
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await Shell.Current.GoToAsync(nameof(Siemens_p300_NetConfigView));
        }

        public async Task NavigateToScaling(t_S7TagViewModel s7TagView)
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await MopupService.Instance.PushAsync(new Scaling(s7TagView));
        }

        public async Task CloseMopout()
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await MopupService.Instance.PopAsync();
        }

        public async Task NavigateToSaveTags(IEnumerable<t_S7TagViewModel> s7TagViewModels)
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await MopupService.Instance.PushAsync(new t_SaveTagsView(new t_SaveTagsViewModel(Shell.Current.Handler.MauiContext.Services.GetService<ICoreServices>(), Shell.Current.Handler.MauiContext.Services.GetService<IJsonService>(),s7TagViewModels)));
        }

        public async Task NavigateToConversion(t_S7TagViewModel s7TagView)
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await MopupService.Instance.PushAsync(new TagConversion(s7TagView));
        }

        public async Task NavigateToProportion()
        {
            await Shell.Current.GoToAsync(nameof(Formulas_p100_ProportionView));
        }

        public async Task NavigateToAbb()
        {
            await Shell.Current.GoToAsync(nameof(Formulas_p200_InverterView));
        }

        public async Task NavigateToPreviewPushModalAsync()
        {
            await Shell.Current.GoToAsync("..");
        }


    }
}
