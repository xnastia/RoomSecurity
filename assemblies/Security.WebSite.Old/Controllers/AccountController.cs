using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Security.WebSite.Old.Models;

namespace Security.WebSite.Old.Controllers
{
    public class AccountController : Controller
    {
        private SecurityDbContext _securityDbContext = new SecurityDbContext();

        public SecurityDbContext SecurityDbContext
        {
            get
            {
                return _securityDbContext;
            }

            set
            {
                _securityDbContext = value;
            }
        }

        public ActionResult Login()
        {
          return View("Login");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Account");
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
          if (ModelState.IsValid)
            {
                var registeredUser = SecurityDbContext.Users
                    //.FirstOrDefault(user => user.Email == loginViewModel.Email && user.Password == loginViewModel.Password);
                    .First();

                if (registeredUser != null)
                {
                    DoLogin(registeredUser, loginViewModel);
                    return RedirectToAction("Index", "SecurityDashboard");
                }

                ModelState.AddModelError("", "Incorrect username or password");
                return View("Login");
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

    }
}
    