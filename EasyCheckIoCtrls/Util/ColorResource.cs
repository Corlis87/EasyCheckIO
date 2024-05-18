using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCtrls.Util
{
    public partial class ColorResource : ResourceDictionary
    {
        public static Color GetColor(string key, Color fallBack = default)
        {
            if (Application.Current.Resources.TryGetValue(key, out object value))
            {
                return (Color)value;
            }
            else
            {
                return fallBack ?? Colors.Transparent;
            }
        }

        public static Color GetColor(string lightKey, string darkKey, Color fallBack = default)
        {
            var key = Application.Current.RequestedTheme == AppTheme.Light ? lightKey : darkKey;

            if (Application.Current.Resources.TryGetValue(key, out object value))
            {
                return (Color)value;
            }
            else
            {
                return fallBack ?? Colors.Transparent;
            }
        }
    }
}