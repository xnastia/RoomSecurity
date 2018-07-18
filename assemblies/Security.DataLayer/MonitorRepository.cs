using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataLayer
{
    class MonitorRepository
    {
        private SecurityDbContext _securityDbContext = new SecurityDbContext();
        public Monitor GetMonitorById(int monitorId)
        {
            return _securityDbContext.Monitors.Single(monitor => monitor.Id == monitorId);
        }
}
