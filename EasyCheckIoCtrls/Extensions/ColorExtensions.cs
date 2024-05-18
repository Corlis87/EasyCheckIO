using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkCtrls.Extensions
{
    public static class ColorExtensions
    {
        public static bool IsNullOrTransparent(this Color color)
        {
            return color == null || color == Colors.Transparent;
        }

        public static Brush ToSolidColorBrush(this Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}