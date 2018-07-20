using System.Net.Http.Formatting;
using System.Web.Http;
using Security.BusinessLogic;

namespace Security.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        //string email, string password
        [AcceptVerbs("Post")]
        public IHttpActionResult Post([FromBody]FormDataCollection formData)
        {
            var email = formData.Get("email");
            var password = formData.Get("password");

            //TODO: authenticate user
            var isValidUser = new SecurityApi().IsValidtUser(email, password);

            if (isValidUser)
                return Ok();
            return Unauthorized();
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