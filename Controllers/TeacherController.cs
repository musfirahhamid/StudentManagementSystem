using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        private ManagementContext _managementContext;
        public TeacherController()
        {
            _managementContext = new ManagementContext();
        }
        // GET: Teacher
        public ActionResult Index()
        {
            var teacher = new Teacher
            {
                Id = 1,
                FirstName = "Teacher",
                LastName = "Amenda",
                Qualification = "MBA"
            };
            return View(teacher);
        }

        public ActionResult GetTeacher()
        {
            var teacher = _managementContext.Teachers.ToList();
            return View(teacher);
        }

        public ActionResult ViewTeacher(int id)
        {
            var teacher = _managementContext.Teachers.FirstOrDefault(t => t.Id == id);
            return View(teacher);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            _managementContext.Teachers.Add(teacher);
            _managementContext.SaveChanges();
            return RedirectToAction("GetTeacher");
        }
    }
}