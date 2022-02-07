using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Models
{
    public class buyingItem
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }
}
