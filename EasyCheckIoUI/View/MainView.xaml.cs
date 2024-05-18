namespace EasyCheckIoUI.View;
using EasyCheckIoCore.ViewModel;
public partial class MainView : ContentPage
{
	public MainView(object bindingContext)
    {
        InitializeComponent();

        BindingContext = bindingContext;
       
    }
}