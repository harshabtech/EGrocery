using EGrocery1.Data;
using EGrocery1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EGrocery1.Controllers
{
    public class PasswordResetController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PasswordResetController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
       public IActionResult Index(IFormCollection f)
        {
            CustomerDetails obj = new CustomerDetails();
            string mailid = f["mail"].ToString();

            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randpass = new string(Enumerable.Repeat(chars, 10)
                                .Select(s => s[random.Next(s.Length)]).ToArray());

            IEnumerable<CustomerDetails> dbuser = (from user in _db.CustomerDetails
                                                    where user.email.Equals(mailid)
                                                   select user);
            
            if (dbuser.Count()==0)
            {
                ViewBag.Error = "Entered Email isn't registered!";
                return View();
            }
            else
            {
                foreach (var user in dbuser)
                {
                    {
                        user.password = randpass;
                    }

                }
            }
            
            _db.SaveChanges();

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("nalavalaharsha@gmail.com");
                mail.To.Add(mailid);
                mail.Subject = "Reset Password";
                mail.Body = $"Your Reset Password is : {randpass}";
                mail.IsBodyHtml = true;
                

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("nalavalaharsha@gmail.com", "aligackmbsqfwhen");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            return RedirectToAction("Index", "Login");
        }

        public IActionResult reset()
        {
            return View();
        }
    }
}
