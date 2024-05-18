using Serilog;
using Serilog.Core;

namespace EasyCheckIoUI.View;

public partial class EventLogView : ContentPage
{
    public EventLogView(object bindingContext)
    {
        InitializeComponent();

        BindingContext = bindingContext;
        var connectionString = FileSystem.AppDataDirectory + "/Project_Logs.db";
        var levelSwitch = new LoggingLevelSwitch();
        Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                 .WriteTo.Debug()
                .WriteTo.SQLite(connectionString, tableName: "Project_Logs")
                .Enrich.FromLogContext()
                .CreateLogger();
    }
}