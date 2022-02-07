using EGrocery1.Data;
using EGrocery1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class LoginController : Controller
    {
        public static int userId = 0;
        private readonly ApplicationDbContext _db;
        public LoginController(ApplicationDbContext db)
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
            IEnumerable<CustomerDetails> customers = _db.CustomerDetails;
            foreach (var customer in customers)
            {
                if (obj.uname == customer.email)
                {
                    string password = (from item in _db.CustomerDetails
                                       where item.email.Equals(obj.uname.ToString())
                                       select item.password).First().ToString();
                    if (obj.password == password.ToString())
                    {
                        userId = (from item in _db.CustomerDetails
                                  where item.email.Equals(obj.uname.ToString())
                                  select item.Id).First();
                        return RedirectToAction("Index", "HomePage");
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
            LoginController.userId = 0;
            return RedirectToAction("Index","MainPage");
        }
    }
}
