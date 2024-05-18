﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCtrls.Extensions
{
    public static class NumericExtensions
    {
        public static T Clamp<T>(this T value, T min, T max) where T : struct, IComparable<T>
        {
            if (Comparer<T>.Default.Compare(value, max) > 0)
            {
                return max;
            }

            if (Comparer<T>.Default.Compare(value, min) < 0)
            {
                return min;
            }

            return value;
        }
    }
}

