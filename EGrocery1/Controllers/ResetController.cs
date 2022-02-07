using EGrocery1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class ResetController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ResetController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormCollection f)
        {
            string password = f["password"].ToString();

            var users = (from details in _db.CustomerDetails
                         where details.Id.Equals(LoginController.userId)
                         select details);
            foreach(var user in users)
            {
                user.password = password;
            }
            _db.SaveChanges();

            return RedirectToAction("Index", "HomePage", new { alertmsg="password has been changed successfully"});
        }
    }
}
