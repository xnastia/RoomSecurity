using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace Security.WebSite.Controllers
{
    public class AccountController : Controller
    {
        //string email, string password
        [System.Web.Http.AcceptVerbs("Post")]
        public async Task<ActionResult> Post([FromBody] FormDataCollection formData)
        {
            HttpClient client = new HttpClient();
            HttpContent content = new FormUrlEncodedContent(formData);
            var response = await client.PostAsync($"http://localhost:8282/Account", content);

            if (response.StatusCode == HttpStatusCode.OK)
                return new HttpStatusCodeResult(200);
            return new HttpStatusCodeResult(401);
        }
    }
}