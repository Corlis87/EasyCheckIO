namespace TiaFrameworkUI.View;
using TiaFrameworkCore.ViewModel;
public partial class _00_MainView : ContentPage
{
	public _00_MainView(object bindingContext)
    {
        InitializeComponent();

        BindingContext = bindingContext;
       
    }
}