using System.Web.Mvc;
using System.Web.Security;

namespace Security.WebSite.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
          return View("Login");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }

        /*[AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
          if (ModelState.IsValid)
          {
              
           }

            return View("Login");
        }

        private void DoLogin(User user, LoginViewModel loginViewModel)
        {
            int timeout = 525600; // 525600 min = 1 year
            var ticket = new FormsAuthenticationTicket(loginViewModel.Email, true, timeout);
            string encrypted = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            cookie.Expires = DateTime.Now.AddMinutes(timeout);
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);
        }
        */
    }
}
    