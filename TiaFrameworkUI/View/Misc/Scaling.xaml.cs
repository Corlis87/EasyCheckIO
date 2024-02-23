using Mopups.Services;

using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.ViewModel;

namespace TiaFrameworkUI.View
{
	public partial class Scaling
    {
		public Scaling(t_S7TagViewModel s7TagView)
		{
			InitializeComponent();
			BindingContext = s7TagView;	
		}
	}
}