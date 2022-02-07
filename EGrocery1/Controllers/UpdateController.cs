using EGrocery1.Data;
using EGrocery1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class UpdateController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UpdateController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [Route("Update/Index/Id")]
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
        [HttpPost]
        public IActionResult update(Item obj)
        {
            _db.Items.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}
