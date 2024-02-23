using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiaFrameworkCore.Program.Events
{
    public static class EventExtensions
    {
        public static void Raise(this EventHandler eventHandler, object sender)

        {
            eventHandler?.Invoke(sender, EventArgs.Empty);
        }

        public static void Raise<T>(this EventHandler<ValueEventArgs<T>> eventHandler, object sender, T value)
        {
            eventHandler?.Invoke(sender, new ValueEventArgs<T>(value));
        }
    }
}