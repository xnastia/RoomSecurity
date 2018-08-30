using System;
using System.Collections.Generic;
using Security.Entities;

namespace Security.BusinessLogic
{
    public interface IMonitorProvider
    {
        Monitor GetMonitor(Guid uiId);
        Monitor CreateMonitor(int monitorId);
        List<MonitorTab> GetMonitorsTabList();
    }
}
