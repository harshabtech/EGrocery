using EGrocery1.Data;
using EGrocery1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class deleteController : Controller
    {
        private readonly ApplicationDbContext _db;
        public deleteController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int id)
        {
            if (Login1Controller.adminId > 0)
            {
                Item obj = _db.Items.Find(id);
                return View(obj);
            }
            ViewBag.Error = "You must login First!";

            return RedirectToAction("Index", "Login1", new { loginAlert = "You must login First!" });
        }

        public IActionResult deletedata(int id)
        {
            _db.Items.Remove(_db.Items.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}
