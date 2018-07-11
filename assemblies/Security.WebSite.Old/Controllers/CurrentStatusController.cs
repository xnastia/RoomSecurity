using System.Collections.Generic;
using System.Web.Http;
using Security.WebSite.Models;

namespace Security.WebSite.Controllers
{
    public class CurrentStatusController : ApiController
    {
        public List<ScannerStatus> GetCurrentStatuses()
        {
            return MonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses;
        }
    }
}
