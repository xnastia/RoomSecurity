using System.Collections.Generic;
using System.Web.Http;
using Security.WebSite.Old.Models;

namespace Security.WebSite.Old.Controllers
{
    public class CurrentStatusController : ApiController
    {
        public List<ScannerStatus> GetCurrentStatuses()
        {
            return MonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses;
        }
    }
}
