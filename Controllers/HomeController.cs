using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Student student1 = new Student( );
            student1.Id = 1;
            student1.FirstName = "John";
            student1.LastName = "Doe";


            //Best for programming
            var student2 = new Student{ Id=2,
                FirstName="Musfirah",
                LastName ="Hamid"
            };
            return View(student1);
        }

    
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}