using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Models
{
    public class OrderedItems
    {
        public string itemname { get; set; }
        public string imageurl { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public string username { get; set; }
    }
}
