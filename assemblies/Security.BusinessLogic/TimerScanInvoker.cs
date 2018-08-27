using System;
using System.Timers;

namespace Security.BusinessLogic
{
    public class TimerScanInvoker : ITimerScanInvoker
    {
        private readonly Timer _checkTimer;

        private readonly int _checkTimerInterval;

        public DateTime CurrentTime { get; set; }

        public event OnScanHandler OnScanInvoke;

        public TimerScanInvoker(int checkTimerInterval = 3000)
        {
            CurrentTime = DateTime.Now;
            _checkTimerInterval = checkTimerInterval;
            _checkTimer = new Timer();
        }
        
        public void Start()
        {
            InitTimer();
        }

        public void End()
        {
            _checkTimer.Enabled = false;
        }

        private void InitTimer()
        {
            _checkTimer.Enabled = true;
            _checkTimer.Interval = _checkTimerInterval;
            _checkTimer.Elapsed += OnScan;
        }

        private void OnScan(object sender, ElapsedEventArgs e)
        {
            OnScanInvoke?.Invoke(CurrentTime);
        }
    }
}