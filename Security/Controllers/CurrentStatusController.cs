using System.Collections.Generic;
using System.Web.Http;
using Security.Models;

namespace Security.Controllers
{
    public class CurrentStatusController : ApiController
    {
        public List<ScannerStatus> GetCurrentStatuses()
        {
            return MonitorSnapshot.GetMonitorSnapshot().SecurityScannerStatuses;
        }
    }
}
