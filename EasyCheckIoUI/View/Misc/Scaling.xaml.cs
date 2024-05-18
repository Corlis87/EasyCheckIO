using Mopups.Services;

using EasyCheckIoCore.Shared._03_DataBlock;
using EasyCheckIoCore.ViewModel;

namespace EasyCheckIoUI.View
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