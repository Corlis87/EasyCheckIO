using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoUI.Converters
{
    public class ByteToBitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            var bitToReturn = Int32.Parse((string)parameter);

            var byteToConvert = 1;
            int mask = 1 << (bitToReturn); // if "bitToReturn" is 1-based
                                                   // int mask = 1 << bitToReturn; // if "bitToReturn" is 0-based
            if (value !=null)
                byteToConvert = System.Convert.ToInt32(value);
            else
                byteToConvert = 0;

            var result = (byteToConvert & mask) != 0;

            return  result? Colors.Red:Colors.Green ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}