using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Security.BusinessLogic;
using Security.DataLayer;

namespace Security.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        //string email, string password
        public HttpResponseMessage Post([FromBody] string a)
        {
            //User user = new SecurityApi().GetUser(email, password);

            return Request.CreateResponse(HttpStatusCode.Unauthorized, a);
        }
    

        /*private void DoLogin(User user, LoginViewModel loginViewModel)
        {
            int timeout = 525600; // 525600 min = 1 year
            var ticket = new FormsAuthenticationTicket(loginViewModel.Email, true, timeout);
            string encrypted = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            cookie.Expires = DateTime.Now.AddMinutes(timeout);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);
        }*/
    }
}