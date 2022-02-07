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
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PaymentController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public IActionResult Index(IFormCollection f)
        {
            int quantity = Convert.ToInt32(f["quantity"].ToString());
            string itemName = f["item"].ToString();
            var carts = _db.CartData.Where(w => w.itemName.Equals(itemName));
            foreach (var item in carts)
            {
                item.quantity = quantity;
                item.price *= quantity;
            }
            _db.SaveChanges();

            
            int itemId = (from item in _db.Items
                          where item.itemName.Equals(itemName)
                          select item.Id).First();

            int quantityAvailable = (from item in _db.Items
                                     where item.itemName.Equals(itemName)
                                     select item.quantityAvailable).First();
            if (quantity <= quantityAvailable)
            {
                var cols = _db.Items.Where(w => w.itemName.Equals(itemName));
                foreach (var item in cols)
                {
                    item.quantityAvailable -= quantity;
                }
                _db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            buyingItem obj = new buyingItem();
            obj.Id = itemId;
            obj.name = itemName;
            obj.price = (from item in _db.Items
                         where item.Id.Equals(itemId)
                         select item.price).First();
            obj.quantity = quantity;
            obj.url = (from item in _db.Items
                       where item.Id.Equals(itemId)
                       select item.imageUrl2).First();

            return View(obj);
        }
    }
}
