using EGrocery1.Data;
using EGrocery1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class OrderedItemsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrderedItemsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<OrderedItems> obj = new List<OrderedItems>();
            var items = _db.CartData;
            foreach (var item in items)
            {
                obj.Add(new OrderedItems() { itemname = item.itemName,
                                             imageurl = item.imageurl,
                                             quantity = item.quantity,
                                             price = item.price,
                                             username = (from user in _db.CustomerDetails
                                                         where user.Id.Equals(item.userId)
                                                         select user.firstName).First().ToString()
                                            });
            }
            return View(obj);
        }
    }
}
