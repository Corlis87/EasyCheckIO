using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkCore.Siemens._03_DataBlock
{
    public class S7NetConfig : ObservableObject
    {
        private string _Address = string.Empty;

        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;

                OnPropertyChanged(nameof(Address));
            }
        }

        private int _Rack;
        public int Rack
        {
            get { return _Rack; }
            set
            {
                _Rack = value;
                OnPropertyChanged(nameof(Rack));
            }
        }

        private int _Slot;

        public int Slot
        {
            get { return _Slot; }
            set
            {
                _Slot = value;
                OnPropertyChanged(nameof(Slot));
            }
        }


    }
}
