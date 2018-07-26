using System.Linq;

namespace Security.DataLayer
{
    class MonitorRepository
    {
        private readonly SecurityDbContext _securityDbContext = new SecurityDbContext();

        public Monitor GetMonitorById(int monitorId)
        {
            return _securityDbContext.Monitors.Single(monitor => monitor.Id == monitorId);
        }
    }
}