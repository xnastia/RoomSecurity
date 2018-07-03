namespace Security.Entities
{
    public interface ITimerScanInvoker
    {
        event OnScanHandler OnScanInvoke;

        void End();

        void Start();
    }
}