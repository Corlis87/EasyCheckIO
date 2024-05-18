using System.Windows.Input;

namespace EasyCheckIoUI.View;

public partial class f_SelectFileMenu : ContentView
{
    public f_SelectFileMenu()
    {
        InitializeComponent();
    }



    public static readonly BindableProperty LoadFileProperty = BindableProperty.Create(
    nameof(LoadFile),
     typeof(ICommand),
    typeof(f_SelectFileMenu),
    null);

    public ICommand LoadFile
    {
        get => (ICommand)GetValue(LoadFileProperty);
        set => SetValue(LoadFileProperty, value);
    }

    public static readonly BindableProperty RemoveFileProperty = BindableProperty.Create(
    nameof(RemoveFile),
    typeof(ICommand),
    typeof(f_SelectFileMenu),
    null);

    public ICommand RemoveFile
    {
        get => (ICommand)GetValue(RemoveFileProperty);
        set => SetValue(RemoveFileProperty, value);
    }

    public static readonly BindableProperty RenameFileProperty = BindableProperty.Create(
   nameof(RenameFile),
   typeof(ICommand),
   typeof(f_SelectFileMenu),
   null);

    public ICommand RenameFile
    {
        get => (ICommand)GetValue(RenameFileProperty);
        set => SetValue(RenameFileProperty, value);
    }

    public static readonly BindableProperty CloseMenuProperty = BindableProperty.Create(
 nameof(CloseMenu),
 typeof(ICommand),
 typeof(f_SelectFileMenu),
 null);

    public ICommand CloseMenu
    {
        get => (ICommand)GetValue(CloseMenuProperty);
        set => SetValue(CloseMenuProperty, value);
    }

    public static readonly BindableProperty ExportFileProperty = BindableProperty.Create(
nameof(ExportFile),
typeof(ICommand),
typeof(f_SelectFileMenu),
null);

    public ICommand ExportFile
    {
        get => (ICommand)GetValue(ExportFileProperty);
        set => SetValue(ExportFileProperty, value);
    }
}