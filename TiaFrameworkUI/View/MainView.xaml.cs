namespace TiaFrameworkUI.View;
using TiaFrameworkCore.ViewModel;
public partial class MainView : ContentPage
{
	public MainView(object bindingContext)
    {
        InitializeComponent();

        BindingContext = bindingContext;
       
    }
}