using EGrocery1.Data;
using EGrocery1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (Login1Controller.adminId > 0)
            {
                ViewBag.UserName = (from user in _db.Admin
                                    where user.Id.Equals(Login1Controller.adminId)
                                    select user.firstName).First().ToString();
                IEnumerable<Item> obj = _db.Items;
                return View(obj);
            }
            ViewBag.Error = "You must login First!";

            return RedirectToAction("Index", "Login",  new { loginAlert = "You must login First!" });
    
        }

       
    }
}
