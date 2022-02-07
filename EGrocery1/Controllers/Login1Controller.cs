using EGrocery1.Data;
using EGrocery1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class Login1Controller : Controller
    {
        public static int adminId = 0;
        private readonly ApplicationDbContext _db;
        public Login1Controller(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string loginAlert)
        {
            ViewBag.Error = loginAlert;
            return View();
        }

        [HttpPost]

        public IActionResult Index(login obj)
        {
            IEnumerable<Admin> admins = _db.Admin;
            foreach (var admin in admins)
            {
                if (obj.uname == admin.email)
                {
                    string password = (from item in _db.Admin
                                       where item.email.Equals(obj.uname.ToString())
                                       select item.password).First().ToString();
                    if (obj.password == password.ToString())
                    {
                        adminId = (from item in _db.Admin
                                  where item.email.Equals(obj.uname.ToString())
                                  select item.Id).First();
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.Error = "password or username is mismatch!";
                        return View("Index");
                    }
                }
            }

            ViewBag.Error = "Entered Email does not exist!";
            return View("Index");
        }

        public IActionResult Logout()
        {
            Login1Controller.adminId = 0;
            return RedirectToAction("Index", "MainPage");
        }
    }
}
