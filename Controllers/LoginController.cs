using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TestApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TestApp.Controllers
{
    public class LoginController : Controller
    {
        Context UserDb = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Girilen login bilgilerinin veritabanında sorgulanması//

        [HttpPost]
        public async Task<IActionResult> Index(LoginAccounts Value)
        {
            var Entry = UserDb.LoginAccounts.FirstOrDefault(x => x.Username == Value.Username && x.Password == Value.Password);
            if (Entry != null)
            {
                var claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, Value.Username)
                };

                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        //Oturum kapatma işlemi//

        [HttpGet]
        public async Task<IActionResult> LogOut ()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Register()
        {
            return RedirectToAction("Register", "Register");
        }
    }
}
