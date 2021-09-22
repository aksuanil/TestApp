using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;


namespace TestApp.Controllers
{
    public class RegisterController : Controller
    {
        Context UserDb = new Context();
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        //Yeni kullanıcı kaydının veritabanına işlenmesi//

        [Route("Register")]
        [HttpPost]
        public IActionResult Register(LoginAccounts AddAccount)
        {
            if (ModelState.IsValid)
            {
                UserDb.LoginAccounts.Add(AddAccount);
                UserDb.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
   
}
