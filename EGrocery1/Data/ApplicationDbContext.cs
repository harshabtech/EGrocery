using EGrocery1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGrocery1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<MyCart> CartData { get; set; }
        public DbSet<Admin> Admin { get; set; }
    }
}
