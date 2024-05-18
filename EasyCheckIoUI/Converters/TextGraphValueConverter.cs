using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoUI.TextGraphList;

namespace EasyCheckIoUI.Converters
{
    public class TextGraphValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (parameter is string name && (value is int || value.GetType().IsEnum))
            {
                var result = TextGraph.GetMessage(name, (int)value);
                return result;
            }
            return new ArgumentException($"{nameof(TextGraphValueConverter)} | Converter");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string name && (value is string))
                return TextGraph.GetIndex(name, (string)value, targetType);

            return new ArgumentException($"{nameof(TextGraphValueConverter)} | ConverterBack");
        }
    }
}