namespace EasyCheckIoUI.View;

public partial class ExcelView : ContentPage
{
	public ExcelView(object bindingContext)
    {
        InitializeComponent();

        BindingContext = bindingContext;
    }
}