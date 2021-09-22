using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class DashboardController : Controller
    {
        Context UserDb = new Context();
        //Veritabanının dashboard üzerinde üye girişi yapanlara listelenmesi//
        [Authorize]
        public IActionResult Index()
        {
            var Values = UserDb.Users.ToList();
            return View(Values);
        }
        [HttpGet]
        public IActionResult YeniKayıt()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniKayıt(Dashboard AddValue)
        {
            UserDb.Users.Add(AddValue);
            UserDb.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult KayıtSil(int Id)
        {
            var Reg = UserDb.Users.Find(Id);
            UserDb.Users.Remove(Reg);
            UserDb.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult KayıtGetir(int Id)
        {
            var Reg = UserDb.Users.Find(Id);
            return View("KayıtGetir", Reg);
        }
        public IActionResult KayıtDüzenle(Dashboard NewValue)
        {
            var Reg = UserDb.Users.Find(NewValue.Id);
            Reg.Name = NewValue.Name;
            Reg.lastName = NewValue.lastName;
            Reg.Mail = NewValue.Mail;
            Reg.Phone = NewValue.Phone;
            UserDb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
