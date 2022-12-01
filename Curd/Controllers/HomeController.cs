using Curd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using Curd.EfModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Curd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Entities _db = new Entities();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Students = new List<Student>
            {
                new Student{ Id = 1, Name = "tuantam", Email ="tuantam@123.com"},
                new Student{ Id = 2, Name = "tuantam", Email ="tuantam@123.com"},
                new Student{ Id = 3, Name = "tuantam", Email ="tuantam@123.com"},
                new Student{ Id = 4, Name = "tuantam", Email ="tuantam@123.com"}
            };
            //ViewBag.Student = Students;
            //optison2 suwr dung view data
            ViewData["students"] = Students;
            return View();

        }
        public IActionResult Login()
        {
            return Login();
        }
        [HttpPost, ActionName("Login")]

        
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact formData)
        {
            if (!ModelState.IsValid)
            {

                return View(formData);
            }
            TempData["message"] = " thank you for  your query";
            return RedirectToAction("Contact");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
