using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Item Name is Required")]
        public string itemName { get; set; }
        [Required(ErrorMessage = "Url for offer is Required")]
        public string imageUrl { get; set; }
        [Required(ErrorMessage = "Product image is Requirde")]
        public string imageUrl2 { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price cannot be negative value")]
        public int price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity cannot be negative value")]
        public int quantityAvailable { get; set; }
    }
}
