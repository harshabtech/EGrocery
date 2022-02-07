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
    public class MyCartController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MyCartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (LoginController.userId > 0)
            {
                IEnumerable<MyCart> obj = (from item in _db.CartData
                                           where item.userId.Equals(LoginController.userId)
                                           select item);
                ViewBag.UserName = (from user in _db.CustomerDetails
                                    where user.Id.Equals(LoginController.userId)
                                    select user.firstName).First().ToString();

                return View(obj);
            }
            ViewBag.Error = "You must login First!";

            return RedirectToAction("Index", "Login", new { loginAlert = "You must login First!" });
        }
        public IActionResult removeItem(IFormCollection f)
        {
            int id = Convert.ToInt32(f["itemId"]);
            _db.CartData.Remove(_db.CartData.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
