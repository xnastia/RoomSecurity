using System;
using System.Collections.Generic;

namespace Security.Entities.DB
{
    public interface IMonitorRepository
    {
        int? GetMonitorIdByUiId(Guid uiId);
        List<MonitorTab> GeMonitorTabs(string user);
    }
}
