using EGrocery1.Data;
using EGrocery1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class HomePageController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomePageController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string alertmsg)
        {
            if (LoginController.userId > 0)
            {
                ViewBag.Success = alertmsg;
                ViewBag.UserName = (from user in _db.CustomerDetails
                                    where user.Id.Equals(LoginController.userId)
                                    select user.firstName).First().ToString();
                IEnumerable<Item> obj = _db.Items;
                return View(obj);
            }
            else
            {
                ViewBag.Error = "You must login First!";

                return RedirectToAction("Index", "Login", new { loginAlert = "You must login First!" });
            }
            
        }
       

    }


}
