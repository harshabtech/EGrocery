using EGrocery1.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class MainPageController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MainPageController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var obj = _db.Items;
            return View(obj);
        }
    }
}
