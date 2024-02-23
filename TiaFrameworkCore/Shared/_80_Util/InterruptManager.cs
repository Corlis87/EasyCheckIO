using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkCore.Shared._80_Util
{
    public class InterruptManager
    {
        #region Fields

        private List<Interrupt> _Tmr = new List<Interrupt>();
        private static InterruptManager _Internal = new InterruptManager();
     
        #endregion

        #region ctr
        public InterruptManager()
        {
            _Internal = this;
        }
        #endregion

        #region Start
        internal Interrupt Start(int millisecond, bool repeats, Action onTime)
        {
            var timer = new Interrupt();
            timer.Initialize(onTime, millisecond);
            _Tmr.Add(timer);
            return timer;
        }
        internal Interrupt Start(int millisecond, bool repeats, Func<Task> onTime)
        {

            var timer = new Interrupt();
            timer.Initialize(onTime, millisecond);
            _Tmr.Add(timer);
            return timer;
        }
        #endregion

        #region Initialize
        public static Interrupt Initialize(int timeInSeconds, bool repeats, object context, Action onTime)
        {
            return _Internal.Start(timeInSeconds, repeats, onTime);
        }
        public static Interrupt Initialize(int timeInSeconds, bool repeats, object context, Func<Task> onTime)
        {
            return _Internal.Start(timeInSeconds, repeats, onTime);
        }
        #endregion

    }
}

