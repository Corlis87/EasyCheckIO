﻿using System;

// PR Fix for entry focus bug #242
namespace Ctrls.Droid
{
    public class SoftKeyboardEventArgs : EventArgs
    {
        public SoftKeyboardEventArgs(bool isVisible)
        {
            IsVisible = isVisible;
        }

        public bool IsVisible { get; private set; }
    }
}