using System.Collections;

namespace TiaFrameworkUI.View;

public partial class SiemensCompileView : ContentPage
{
	public SiemensCompileView(object bindingContext)
    {
        InitializeComponent();
        BindingContext = bindingContext;
    }

}