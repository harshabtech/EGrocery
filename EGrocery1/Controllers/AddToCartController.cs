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
    public class AddToCartController : Controller
    {
        public int quan;
        private readonly ApplicationDbContext _db;
        public AddToCartController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int id)
        {
            if (LoginController.userId > 0)
            {
                Item obj = _db.Items.Find(id);
                return View(obj);
            }
            ViewBag.Error = "You must login First!";

            return RedirectToAction("Index", "Login", new { loginAlert = "You must login First!" });
        }
        [HttpPost]
        public IActionResult Index(IFormCollection f)
        {
            if (LoginController.userId > 0)
            {
                int id = Convert.ToInt32(f["id"]);
                int quantity = Convert.ToInt32(f["quantity"]);
                int quantityAvailable = (from item in _db.Items
                                         where item.Id.Equals(id)
                                         select item.quantityAvailable).First();
                MyCart obj = new MyCart();
                obj.itemName = (from item in _db.Items
                                where item.Id.Equals(id)
                                select item.itemName).First().ToString();
                obj.price = (from item in _db.Items
                             where item.Id.Equals(id)
                             select item.price).First();
                if (quantity >= quantityAvailable)
                {
                    ViewBag.Error = "Entered amount of quantity is not availble! please re-enter the quantity:)";
                    Item obj1 = _db.Items.Find(id);
                    return View(obj1);

                }
                obj.quantity = quantity;
                obj.imageurl = (from item in _db.Items
                                where item.Id.Equals(id)
                                select item.imageUrl2).First().ToString();
                obj.userId = LoginController.userId;

                _db.CartData.Add(obj);
                _db.SaveChanges();


                return RedirectToAction("Index", "HomePage");
            }
            return RedirectToAction("Index", "Login", new { alertmsg = "please login here!"});

        }
    }
}
