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
                var monitorsRolesId = _securityDbContext.Monitors.Join(_securityDbContext.RolesMonitors,
                    m => m.Id, rm => rm.MonitorId, (m, rm) => new { m.UiId, m.Name, rm.RoleId });
                int a = monitorsRolesId.Count();
                var monitorsRolesUserId = monitorsRolesId.Join(_securityDbContext.UsersRoles,
                    m => m.RoleId, ur => ur.RoleId, (m, ur) => new { m.UiId, m.Name, ur.UserId });
                int b = monitorsRolesId.Count();
                var userId = _securityDbContext.Users.Where(u => u.Email == user).
                    Select(u => u.Id).FirstOrDefault();
                var monitorsUiIdName = monitorsRolesUserId.Where(m => m.UserId == userId)
                    .Select(m => new { m.UiId, m.Name });
                int c = monitorsRolesId.Count();

                foreach (var monitor in monitorsUiIdName)
                {
                    MonitorTab monitorTab = new MonitorTab() { Id = monitor.UiId, Name = monitor.Name };
                    monitorTabs.Add(monitorTab);
                }
            }
            return monitorTabs;
        }
    }
}