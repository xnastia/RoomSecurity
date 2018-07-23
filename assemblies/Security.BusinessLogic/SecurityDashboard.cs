namespace Security.BusinessLogic
{
    public class SecurityDashboard
    {
        private readonly ITimerScanInvoker _timerScanInvoker;

        public Monitor Monitor { get; }

        public SecurityDashboard(ITimerScanInvoker timerScanInvoker, Monitor monitor)
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