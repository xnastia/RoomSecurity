using System;
using System.Collections.Generic;
using System.Linq;
using Security.Entities;
using Security.Entities.DB;

namespace Security.DataLayer.EF
{
    public class MonitorRepository : IMonitorRepository
    {
        private readonly SecurityDbContext _securityDbContext = new SecurityDbContext();

        public int? GetMonitorIdByUiId(Guid uiId)
        {
            int? id;
            using (var securityDbContext = new SecurityDbContext())
            {
                id = _securityDbContext.Monitors.Single(monitor => monitor.UiId == uiId).Id;
            }
            return id;
        }

        public List<MonitorTab> GeMonitorTabs(string user)
        {
            List<MonitorTab> monitorTabs = new List<MonitorTab>();
            using (var securityDbContext = new SecurityDbContext())
            {
                var monitors = _securityDbContext.Monitors.Select(monitor => new {monitor.UiId, monitor.Name});
                foreach (var monitor in monitors)
                {
                    MonitorTab monitorTab = new MonitorTab() {Id = monitor.UiId, Name = monitor.Name};
                    monitorTabs.Add(monitorTab);
                }
            }
            return monitorTabs;
        }
    }
}