using System;

namespace Security.BusinessLogic
{
    public interface IMonitor
    {
        event CheckDoneHandler EventOnCheckDone;
        event CheckDoneHandler EventOnIntruderDetected;

        void Scan(DateTime currentTime);
    }
}