using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Security.Entities;

namespace Security.WebSite.Controllers
{
    public class SecurityDashboardController : ApiController
    {
        //securitydashboard/getmonitorstatus?monitorid=1
        public async Task<DashboardStatus> GetMonitorStatus(int monitorId)
        {
            DashboardStatus result = null;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:8282/securitydashboard/getmonitorstatus?monitorid={monitorId}");

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<DashboardStatus>();
            }

            return result;
        }
    }
}
