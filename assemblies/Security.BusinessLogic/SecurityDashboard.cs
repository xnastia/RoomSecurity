﻿namespace Security.BusinessLogic
{
    public class SecurityDashboard
    {
        private readonly ITimerScanInvoker _timerScanInvoker;

        public IMonitor Monitor { get; }

        public SecurityDashboard(ITimerScanInvoker timerScanInvoker, IMonitor monitor)
        {
            _timerScanInvoker = timerScanInvoker;
            Monitor = monitor;
        }

        public void StartScanning()
        {
            _timerScanInvoker.OnScanInvoke += Monitor.Scan;
            _timerScanInvoker.Start();
        }

        public void StopScanning()
        {
            _timerScanInvoker.OnScanInvoke -= Monitor.Scan;
            _timerScanInvoker.End();
        }
    }
}