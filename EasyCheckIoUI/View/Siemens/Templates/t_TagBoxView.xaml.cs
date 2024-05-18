using DocumentFormat.OpenXml.ExtendedProperties;

namespace EasyCheckIoUI.View;

public partial class t_TagBoxView : ContentView
{
	public t_TagBoxView()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (!Notes.IsVisible)
            Notes.IsVisible = true;
		else
            Notes.IsVisible = false;	
    }
}