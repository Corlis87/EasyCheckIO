using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Shared._22_Services;
using EasyCheckIoCore.Siemens._03_DataBlock;
using EasyCheckIoCore.ViewModel;
using EasyCheckIoCore.ViewModel.Siemens.Template;
using EasyCheckIoUI.View;
using EasyCheckIoUI.View.Form;

namespace EasyCheckIoUI.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToHwDevicesView()
        {
            await Shell.Current.GoToAsync(nameof(SiemensView));
        }

        public async Task NavigateToMainView()
        {
            await Shell.Current.GoToAsync(nameof(MainView));
        }

        public async Task NavigateToHwDeviceConfigView()
        {
            await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<SiemensConfigView>());
            //  await Shell.Current.GoToAsync("//" + nameof(HwDeviceConfigView));
        }

        public async Task NavigateToHwDeviceEditView(S7Tag tag)
        {
            await Shell.Current.Navigation.PushModalAsync(new SiemensEditorView(new SiemensEditorViewModel(Shell.Current.Handler.MauiContext.Services.GetService<ICoreServices>(),tag, Shell.Current.Handler.MauiContext.Services.GetService<IS7Lgc>())));
            //  await Shell.Current.GoToAsync("//" + nameof(HwDeviceConfigView));
        }

        public async Task NavigateToHwDeviceTagsView()
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await Shell.Current.GoToAsync(nameof(SiemensCompileView));
        }

        public async Task NavigateToModuleSearchTagView()
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await Shell.Current.GoToAsync(nameof(SiemensSearchView));
        }

        public async Task NavigateToLoadFileView()
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await Shell.Current.GoToAsync(nameof(SiemensLoadTagsView));
        }

        public async Task NavigateToCompilePageView()
        {
            await Shell.Current.GoToAsync(nameof(SiemensCompileView));
        }
        public async Task NavigateToHwDeviceEditPlcProfileView()
        {
            //  await Shell.Current.Navigation.PushModalAsync(Shell.Current.Handler.MauiContext.Services.GetService<HwDeviceModulesView>());
            await Shell.Current.GoToAsync(nameof(SiemensNetConfigView));
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
            await Shell.Current.GoToAsync(nameof(FormulasProportionView));
        }

        public async Task NavigateToAbb()
        {
            await Shell.Current.GoToAsync(nameof(FormulasInverterView));
        }

        public async Task NavigateToPreviewPushModalAsync()
        {
            await Shell.Current.GoToAsync("..");
        }


    }
}
