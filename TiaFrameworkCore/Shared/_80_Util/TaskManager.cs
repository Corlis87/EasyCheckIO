using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiaFrameworkCore.Shared._03_DataBlock;
using TiaFrameworkCore.Shared._11_Contracts;

namespace TiaFrameworkCore.Shared._80_Util
{
    public class TaskManager
    {
        #region Field
        private List<TaskInterrupt> _Tmr = new List<TaskInterrupt>();
        private static TaskManager _Internal = new TaskManager();
        #endregion

        #region ctr
        public TaskManager()
            {
                _Internal = this;
            }
            #endregion

        #region Start
            internal TaskInterrupt Start(int millisecond, bool repeats, Action onTime)
            {
                var timer = new TaskInterrupt();
                timer.Initialize(onTime, millisecond);
                _Tmr.Add(timer);
                return timer;
            }
            internal TaskInterrupt Start(int millisecond, bool repeats, Func<Task> onTime)
            {

                var timer = new TaskInterrupt();
                timer.Initialize(onTime, millisecond);
                _Tmr.Add(timer);
                return timer;
            }
            #endregion

        #region Initialize
            public static TaskInterrupt Initialize(int timeInSeconds, bool repeats, object context, Action onTime)
            {
                return _Internal.Start(timeInSeconds, repeats, onTime);
            }
            public static TaskInterrupt Initialize(int timeInSeconds, bool repeats, object context, Func<Task> onTime)
            {
                return _Internal.Start(timeInSeconds, repeats, onTime);
            }

        #endregion

        //    public static async Task CreatePeriodicTask(Func<Task> action, TimeSpan interval,
        //    CancellationToken cancellationToken = default)
        //{
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        await action();
        //        await Task.Delay(interval, cancellationToken);
        //    }
        //}

        //public static async Task CreatePeriodicMethod(Action action, TimeSpan interval,
        //  CancellationToken cancellationToken = default)
        //{
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        var delayTask = Task.Delay(interval, cancellationToken).ConfigureAwait(false);
        //        action();
        //        await delayTask;
        //    }
        //}
    }
}