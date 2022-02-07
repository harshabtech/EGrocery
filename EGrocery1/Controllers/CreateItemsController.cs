using EGrocery1.Data;
using EGrocery1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class CreateItemsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CreateItemsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (Login1Controller.adminId > 0)
            {
                return View();
            }
            ViewBag.Error = "You must login First!";

            return RedirectToAction("Index", "Login1", new { loginAlert = "You must login First!" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Item obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return View(obj);
        }
    }
}
