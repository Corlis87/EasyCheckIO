using AppoMobi.Maui.Gestures;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Handlers.Items;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Mopups.Hosting;
using TiaFrameworkCore.Excel._30_Lgc;
using TiaFrameworkCore.Shared._11_Contracts;
using TiaFrameworkCore.Shared._22_Services;
using TiaFrameworkCore.Shared._23_Store;
using TiaFrameworkCore.Siemens._30_Lgc;
using TiaFrameworkCore.ViewModel;
using TiaFrameworkUI.Services;
using TiaFrameworkUI.TextGraphList;
using TiaFrameworkUI.View;
using TiaFrameworkUI.View.Form;

namespace TiaFrameworkUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                
                .UseMauiCommunityToolkit()
                .ConfigureMopups()
                .UseGestures()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FontAwesome6FreeRegular400.otf", "FontAwesome6Regular");
                    fonts.AddFont("FontAwesome6FreeSolid900.otf", "FontAwesome6Solid");
                    fonts.AddFont("FontAwesome6Brand.otf", "FontAwesome6Brands");
                    fonts.AddFont("fa-regular-400.ttf", "FARegular");
                    fonts.AddFont("fa-brands-400.ttf", "FABrands");
                    fonts.AddFont("fa-solid-900.ttf", "FASolid");
                });

            TextGraph.Initialize();
            TextColor.Initialize();
            builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
            builder.Services.AddSingleton<IS7Com, S7Com>();
            builder.Services.AddSingleton<IS7Lgc,S7Lgc>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IMessageService, MessageService>();
            builder.Services.AddSingleton<ICoreServices,CoreServices>();
            builder.Services.AddSingleton<IExcelLgc,ExcelLgc>();
            builder.Services.AddSingleton<IDirectoryService, DirectoryService>();
            builder.Services.AddSingleton<IJsonService,JsonService>();
            builder.Services.AddSingleton<NotificationStore>(new NotificationStore());
            builder.Services.AddSingleton<INotificationService, NotificationService>();

            builder.Services.AddSingleton<_00_MainViewModel>();
            builder.Services.AddSingleton<_00_MainView>(
             s => new _00_MainView(s.GetRequiredService<_00_MainViewModel>()));

          

            builder.Services.AddSingleton<_10_SiemensViewModel>();
            builder.Services.AddSingleton<_10_SiemensView>(
             s => new _10_SiemensView(s.GetRequiredService<_10_SiemensViewModel>()));

            builder.Services.AddTransient<Siemens_m100_ConfigViewModel>();
            builder.Services.AddTransient<Siemens_m100_ConfigView>(
             s => new Siemens_m100_ConfigView(s.GetRequiredService<Siemens_m100_ConfigViewModel>()));

            builder.Services.AddTransient<Siemens_p300_NetConfigViewModel>();
            builder.Services.AddTransient<Siemens_p300_NetConfigView>(
             s => new Siemens_p300_NetConfigView(s.GetRequiredService<Siemens_p300_NetConfigViewModel>()));

            builder.Services.AddSingleton<Siemens_p400_CompileViewModel>();
            builder.Services.AddSingleton<Siemens_p400_CompileView>(
             s => new Siemens_p400_CompileView(s.GetRequiredService<Siemens_p400_CompileViewModel>()));

            builder.Services.AddTransient<Siemens_p410_SearchViewModel>();
            builder.Services.AddTransient<Siemens_p410_SearchView>(
             s => new Siemens_p410_SearchView(s.GetRequiredService<Siemens_p410_SearchViewModel>()));

            builder.Services.AddTransient<Siemens_p420_LoadTagsViewModel>();
            builder.Services.AddTransient<Siemens_p420_LoadTagsView>(
             s => new Siemens_p420_LoadTagsView(s.GetRequiredService<Siemens_p420_LoadTagsViewModel>()));


            builder.Services.AddSingleton<_30_FormViewModel>();
            builder.Services.AddSingleton<_30_FormulasView>(
             s => new _30_FormulasView(s.GetRequiredService<_30_FormViewModel>()));

            builder.Services.AddSingleton<Formulas_p100_ProportionViewModel>();
            builder.Services.AddSingleton<Formulas_p100_ProportionView>(
             s => new Formulas_p100_ProportionView(s.GetRequiredService<Formulas_p100_ProportionViewModel>()));

            builder.Services.AddTransient<Formulas_p200_InverterViewModel>();
            builder.Services.AddTransient<Formulas_p200_InverterView>(
             s => new Formulas_p200_InverterView(s.GetRequiredService<Formulas_p200_InverterViewModel>()));

            builder.Services.AddTransient<_90_MoreMenuViewModel>();
            builder.Services.AddTransient<MoreMenuView>(
             s => new MoreMenuView(s.GetRequiredService<_90_MoreMenuViewModel>()));


            builder.Services.AddTransient<_40_AllendBradleyViewModel>();
            builder.Services.AddTransient<_40_AllendBradleyView>(
             s => new _40_AllendBradleyView(s.GetRequiredService<_40_AllendBradleyViewModel>()));

            builder.Services.AddTransient<_50_ExcelViewModel >();
            builder.Services.AddTransient<_50_ExcelView>(
             s => new _50_ExcelView(s.GetRequiredService<_50_ExcelViewModel>()));

            builder.Services.AddTransient<_60_OpcViewModel>();
            builder.Services.AddTransient<_60_OpcView>(
             s => new _60_OpcView(s.GetRequiredService<_60_OpcViewModel>()));


            return builder.Build();

            
        }
    }



    
}