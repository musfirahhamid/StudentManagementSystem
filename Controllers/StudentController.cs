using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
      
        private readonly ManagementContext _managementContext;
        public StudentController()
        {
            _managementContext = new ManagementContext();
        }
        // GET: Student
        public ActionResult Index()
        {
            var student = new Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            };
            
            return View(student);
        }

        public ActionResult GetStudent()
        {
            var student = _managementContext.Students.ToList();
            return View(student);
        }

        public ActionResult ViewStudent(int id)
        {
            var student = _managementContext.Students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            _managementContext.Students.Add(student);
            _managementContext.SaveChanges();
            return RedirectToAction("GetStudent");
        }

    }
}