using EasyCheckIoCore.Shared._03_DataBlock;
using EasyCheckIoCore.ViewModel;

namespace EasyCheckIoUI.View;

public partial class TagConversion 
{
	public TagConversion(t_S7TagViewModel s7TagView)
    {
        InitializeComponent();
        BindingContext = s7TagView;
    }
}
