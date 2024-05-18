using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Siemens._03_DataBlock
{
    public class S7Param : ObservableObject
    {

        #region HwConfig

        private S7NetConfig _HwNetConfig;
        public S7NetConfig HwNetConfig
        {
            get { return _HwNetConfig; }
            set
            {
                _HwNetConfig = value;
                OnPropertyChanged("HwNetConfig");
            }
        }

        #endregion

        #region Tags

        private ObservableCollection<S7Tag> _Tags;

        public ObservableCollection<S7Tag> Tags
        {
            get { return _Tags; }
            set
            {
                _Tags = value;
                OnPropertyChanged("Tags");
            }
        }


        #endregion

        public S7Param()
        {
            _HwNetConfig = new S7NetConfig();
            _Tags = new ObservableCollection<S7Tag>();
        }
    }
}
