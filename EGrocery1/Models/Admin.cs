using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "last name is required")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Email field is required")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password field is required")]
        public string password { get; set; }
    }
}
