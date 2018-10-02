using System;
using System.Collections.Generic;

namespace Security.BusinessLogic
{
    public interface IMonitor
    {
        event CheckDoneHandler EventOnCheckDone;
        event CheckDoneHandler EventOnIntruderDetected;
        List<ISecurityScanner> SecurityScanners { get; set; }

        bool IsSame(IMonitor monitor);

        void Scan(DateTime currentTime);
    }
}