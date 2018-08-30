namespace Security.BusinessLogic
{
    public interface ISnapshotProvider
    {
        MonitorSnapshot GetMonitorSnapshot(Monitor monitor);
    }
}