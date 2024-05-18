using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Shared._03_DataBlock
{
    public class Scalex:ObservableObject
    {
        private double _iRaw;
        public double iRaw
        {
            get => _iRaw;
            set => SetProperty(ref _iRaw, value);
        }

        private double _fRaw;
        public double fRaw
        {
            get => _fRaw;
            set => SetProperty(ref _fRaw, value);
        }

        private double _iEng;
        public double iEng
        {
            get => _iEng;
            set => SetProperty(ref _iEng, value);
        }

        private double _fEng;
        public double fEng
        {
            get => _fEng;
            set => SetProperty(ref _fEng, value);
        }

        private double _Eng;
        public double Eng
        {
            get => _Eng;
            set => SetProperty(ref _Eng, value);
        }

        public Scalex()
        {
            iRaw= 0f;
            fRaw= 27648f;
            iEng= 0.0f; 
            fEng= 100.0f; 
        }
        public void Scale(object value)
    {
            if (value is short)
            {
                double normX = ((short)value - iRaw) / (fRaw - iRaw);
                Eng = (normX * (fEng - iEng)) + iEng;
            }
    }
    }
}
