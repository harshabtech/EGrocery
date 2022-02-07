using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Models
{
    public class MyCart
    {
        [Key]
        public int Id { get; set; }
        public string itemName { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string imageurl { get; set; }
        public int userId { get; set; }
    }
}
