using System;
using System.Timers;

namespace Security.Entities
{
    public class TimerScanInvoker : ITimerScanInvoker
    {
        public event OnScanHandler OnScanInvoke;

        private readonly Timer _checkTimer;

        private readonly int _checkTimerInterval;

        private readonly TimeSpan _timerStepSize = new TimeSpan(0, 30, 0);

        public TimerScanInvoker(int checkTimerInterval = 1000)
        {
            _currentTime = new TimeSpan(0, 0, 0);
            _checkTimerInterval = checkTimerInterval;
            _checkTimer = new Timer();
        }

        private TimeSpan _currentTime;

        private void InitTimer()
        {
            _checkTimer.Enabled = true;
            _checkTimer.Interval = _checkTimerInterval;
            _checkTimer.Elapsed += OnScan;
        }

        private void OnScan(object sender, ElapsedEventArgs e)
        {
            _currentTime += _timerStepSize;
            if (_currentTime.Hours >= 24)
                _currentTime = new TimeSpan(0, 0, 0);

            OnScanInvoke?.Invoke(_currentTime);
        }

        public void Start()
        {
            InitTimer();
        }

        public void End()
        {
            _checkTimer.Enabled = false;
        }
    }
}