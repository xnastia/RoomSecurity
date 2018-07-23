namespace Security.BusinessLogic
{
    public interface ITimerScanInvoker
    {
        event OnScanHandler OnScanInvoke;

        void End();

        void Start();
    }
}