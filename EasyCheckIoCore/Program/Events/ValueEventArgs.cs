﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCheckIoCore.Program.Events
{
    public class ValueEventArgs<T>
         : EventArgs
    {
        public ValueEventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
}