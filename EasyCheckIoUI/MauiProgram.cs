using AppoMobi.Maui.Gestures;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Handlers.Items;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Mopups.Hosting;
using Serilog;
using Serilog.Core;
using EasyCheckIoCore.Excel._30_Lgc;
using EasyCheckIoCore.Shared._11_Contracts;
using EasyCheckIoCore.Shared._22_Services;
using EasyCheckIoCore.Shared._23_Store;
using EasyCheckIoCore.Siemens._30_Lgc;
using EasyCheckIoCore.ViewModel;
using EasyCheckIoUI.Services;
using EasyCheckIoUI.TextGraphList;
using EasyCheckIoUI.View;
using EasyCheckIoUI.View.Form;
using UraniumUI;

namespace EasyCheckIoUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
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

            builder.Services.AddMopupsDialogs();
            builder.Services.AddSingleton<IFileSaver>(FileSaver.Default);

            builder.Services.AddSingleton<IMessageService, MessageService>();
            builder.Services.AddSingleton<ICoreServices, CoreServices>();
            builder.Services.AddSingleton<IDirectoryService, DirectoryService>();
            builder.Services.AddSingleton<IJsonService, JsonService>();
            builder.Services.AddSingleton<IEventLogsService, EventLogsService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<NotificationStore>(new NotificationStore());
            builder.Services.AddSingleton<INotificationService, NotificationService>();

            builder.Services.AddSingleton<IS7Com, S7Com>();
            builder.Services.AddSingleton<IS7Lgc, S7Lgc>();
            builder.Services.AddSingleton<IExcelLgc, ExcelLgc>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainView>(
             s => new MainView(s.GetRequiredService<MainViewModel>()));

            builder.Services.AddSingleton<EventLogViewModel>();
            builder.Services.AddSingleton<EventLogView>(
             s => new EventLogView(s.GetRequiredService<EventLogViewModel>()));

            builder.Services.AddSingleton<SiemensViewModel>();
            builder.Services.AddSingleton<SiemensView>(
             s => new SiemensView(s.GetRequiredService<SiemensViewModel>()));

            builder.Services.AddTransient<SiemensConfigViewModel>();
            builder.Services.AddTransient<SiemensConfigView>(
             s => new SiemensConfigView(s.GetRequiredService<SiemensConfigViewModel>()));

            builder.Services.AddTransient<SiemensNetConfigViewModel>();
            builder.Services.AddTransient<SiemensNetConfigView>(
             s => new SiemensNetConfigView(s.GetRequiredService<SiemensNetConfigViewModel>()));

            builder.Services.AddSingleton<SiemensCompileViewModel>();
            builder.Services.AddSingleton<SiemensCompileView>(
             s => new SiemensCompileView(s.GetRequiredService<SiemensCompileViewModel>()));

            builder.Services.AddTransient<SiemensSearchViewModel>();
            builder.Services.AddTransient<SiemensSearchView>(
             s => new SiemensSearchView(s.GetRequiredService<SiemensSearchViewModel>()));

            builder.Services.AddTransient<SiemensLoadTagsViewModel>();
            builder.Services.AddTransient<SiemensLoadTagsView>(
             s => new SiemensLoadTagsView(s.GetRequiredService<SiemensLoadTagsViewModel>()));

            builder.Services.AddSingleton<FormViewModel>();
            builder.Services.AddSingleton<FormulasView>(
             s => new FormulasView(s.GetRequiredService<FormViewModel>()));

            builder.Services.AddSingleton<Formulas_p100_ProportionViewModel>();
            builder.Services.AddSingleton<FormulasProportionView>(
             s => new FormulasProportionView(s.GetRequiredService<Formulas_p100_ProportionViewModel>()));

            builder.Services.AddTransient<Formulas_p200_InverterViewModel>();
            builder.Services.AddTransient<FormulasInverterView>(
             s => new FormulasInverterView(s.GetRequiredService<Formulas_p200_InverterViewModel>()));


            builder.Services.AddTransient<AllendBradleyViewModel>();
            builder.Services.AddTransient<AllendBradleyView>(
             s => new AllendBradleyView(s.GetRequiredService<AllendBradleyViewModel>()));

            builder.Services.AddTransient<ExcelViewModel>();
            builder.Services.AddTransient<ExcelView>(
             s => new ExcelView(s.GetRequiredService<ExcelViewModel>()));

            builder.Services.AddTransient<OpcViewModel>();
            builder.Services.AddTransient<OpcView>(
             s => new OpcView(s.GetRequiredService<OpcViewModel>()));


            return builder.Build();


        }
    }




}