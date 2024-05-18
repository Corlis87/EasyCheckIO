using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoUI.TextGraphList;

namespace EasyCheckIoUI.Converters
{
    public class LoggerLevelToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          if(value != null && value is string) 
            {
                switch (value)
                {
                    case "Verbose":
                        return new FontImageSource { FontFamily = "FASolid" ,Glyph = "\u2713", Color= Colors.Green };
                    case "Information":
                        return new FontImageSource { FontFamily = "FASolid", Glyph = "\uf129", Color = Colors.CadetBlue };
                    case "Error":
                        return new FontImageSource { FontFamily = "FASolid", Glyph = "\ue59a", Color = Colors.Red  };
                    case "Warning":
                        return new FontImageSource { FontFamily = "FASolid", Glyph = "\u26a0", Color = Colors.Yellow  };

                    default: return null;
                }
            }
          else
                return null;

           
        
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return new ArgumentException($"{nameof(LoggerLevelToIconConverter)} | Converter");
        }

    }
}