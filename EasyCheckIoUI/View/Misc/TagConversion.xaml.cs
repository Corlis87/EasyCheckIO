using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.ViewModel;

namespace TiaFrameworkUI.View;

public partial class TagConversion 
{
	public TagConversion(t_S7TagViewModel s7TagView)
    {
        InitializeComponent();
        BindingContext = s7TagView;
    }
}
