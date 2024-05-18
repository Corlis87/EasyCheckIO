using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.ViewModel;

namespace EasyCheckIoCore.Siemens._03_DataBlock
{
    public class S7ViewValue : ObservableObject
    {
        #region Tags

        private ObservableCollection<t_S7TagViewModel> _Tags;

        public ObservableCollection<t_S7TagViewModel> Tags
        {
            get => _Tags;
            set => SetProperty(ref _Tags, value);
        }
        #endregion


        public S7ViewValue()
        {
            _Tags = new ObservableCollection<t_S7TagViewModel>();
        }
    }
}