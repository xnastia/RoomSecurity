using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Security.Models;

namespace Security.Controllers
{
    public class AccountController : Controller
    {
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
            List<User> users = new List<User>()
            {
                new User("Ivan","me@ukr.net","1234"),
                new User("Petro","hru@ukr.net","123456")
            };
            if (ModelState.IsValid)
            {
                var registeredUser = users.FirstOrDefault(user => user.Email == loginViewModel.Email && user.Password == loginViewModel.Password);

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
    