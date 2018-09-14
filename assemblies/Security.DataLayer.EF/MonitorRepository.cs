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
            var monitorTabs = new List<MonitorTab>();
            using (var securityDbContext = new SecurityDbContext())
            {
                /*monitorTabs = securityDbContext.Monitors.Join(securityDbContext.RolesMonitors,
                        m => m.Id, rm => rm.MonitorId, (m, rm) => new {m.UiId, m.Name, rm.RoleId})
                    .Join(securityDbContext.UsersRoles,
                        m => m.RoleId, ur => ur.RoleId, (m, ur) => new {m.UiId, m.Name, ur.UserId})
                    .Where(m => m.UserId == securityDbContext.Users
                                    .Where(u => u.Email == user)
                                    .Select(u => u.Id)
                                    .FirstOrDefault())
                    .Select(m => new MonitorTab {Id = m.UiId, Name = m.Name}).ToList();*/
                System.Data.SqlClient.SqlParameter userParameter = new System.Data.SqlClient.SqlParameter("@email", user);
                monitorTabs = securityDbContext.Database.SqlQuery<MonitorTab>("sp_GetMonitorTabsbyEmail @email", userParameter).ToList();
            }
            return monitorTabs;
        }
    }
}