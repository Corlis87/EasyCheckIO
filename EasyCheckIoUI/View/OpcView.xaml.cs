namespace TiaFrameworkUI.View;

public partial class OpcView : ContentPage
{
    public OpcView(object bindingContext)
    {
        InitializeComponent();

        BindingContext = bindingContext;
    }
}