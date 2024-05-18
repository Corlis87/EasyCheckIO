using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoUI.TextGraphList;

namespace EasyCheckIoUI.Converters
{
    public class TextGraphToItemsourceValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var a = TextGraph.GetList((string)value);
            return a;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string name && (value is string))
                return TextGraph.GetIndex(name, (string)value, targetType);

            return new ArgumentException($"{nameof(TextGraphValueConverter)} | ConverterBack");
        }

    }
}