using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCheckIoCore.Shared._11_Contracts;

namespace EasyCheckIoCore.Shared._03_DataBlock
{
    public class TaskInterrupt:ITaskInterrupt
    {
        #region Static
        private TimeSpan _interval;
        private Action? _action;
        private Func<Task>? _task;
        private bool _count;
        private int _counts;
        private Task? _timerTask;
        CancellationTokenSource source;
        private bool FirstStart;
        #endregion

        #region ctr
        public TaskInterrupt()
        {
            source = new CancellationTokenSource();
        }
        #endregion

        #region Method

        #region Start
        public void Start()
        {
            _timerTask = DoWorkAsync();
        }
        #endregion

        #region Stop
        public async Task StopAsync()
        {
            source.Cancel();
            if (_timerTask is not null)
            {
                await _timerTask;
                _timerTask.Dispose();
            }
            source.Dispose();
        }
        #endregion

        #region Restart

        public async void Restart()
        {
            if (FirstStart)
            {
                FirstStart = true;
                Start();

            }
            else
            {
                if (!source.IsCancellationRequested)
                    await StopAsync();

                source = new CancellationTokenSource();
                Start();
            }
        }
        #endregion

        #region Initialize
        public void Initialize(Action action, int milliseconds, int counts = 0)
        {
            _interval = TimeSpan.FromMilliseconds(milliseconds);
            _action = action;
            _count = counts > 0;
            _counts = counts;
        }
        public void Initialize(Func<Task> task, int milliseconds, int counts = 0)
        {
            _interval = TimeSpan.FromMilliseconds(milliseconds);
            _task = task;
            _count = counts > 0;
            _counts = counts;
        }
        #endregion

        #region DoWorkAsync
        private async Task DoWorkAsync()
        {
            try
            {
                while (!source.IsCancellationRequested)
                {
                    if (_count)
                    {
                        _counts--;
                        if (_counts == 0)
                            source.Cancel();
                    }

                    if (_task is not null)
                    {
                        await _task();
                        await Task.Delay(_interval);
                    }
                    else
                    {
                        _action();
                        await Task.Delay(_interval);
                    }
                }
            }
            catch (TaskCanceledException _)
            {

            }
            catch (OperationCanceledException _)

            {

            }
        }
        #endregion

        #endregion

    }
}