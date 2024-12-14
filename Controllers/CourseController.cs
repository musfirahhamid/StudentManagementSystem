using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ManagementContext _managementContext;
        public CourseController()
            {
            _managementContext = new ManagementContext();
            }
        // GET: Course
        public ActionResult Index()
        {
            var course = _managementContext.Courses.Where(c=> !c.IsDeleted).ToList();
            return View(course);
        }

        //View Details
        public ActionResult ViewDetails(int id)
            {
            var course = _managementContext.Courses.FirstOrDefault(c=>c.Id==id);
            if(course== null)
                {
                return HttpNotFound();
                }
            return View(course);
            }

        //Create Course
        [HttpGet]
        public ActionResult Create()
            {
            return View();
            }

        [HttpPost]
        public ActionResult Create(Course course)
            {
            _managementContext.Courses.Add(course);
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }

        //Update Course
        public ActionResult Update(int id)
            {
            var course = _managementContext.Courses.FirstOrDefault(c=>c.Id==id);
            if(course == null)
                {
                return HttpNotFound();
                }
            return View(course);
            }

        [HttpPost]
        public ActionResult Update(Course course)
            {
            var courses = _managementContext.Entry(course);
            courses.State = System.Data.Entity.EntityState.Modified;
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }

        public ActionResult Delete(int id)
            {
            var course = _managementContext.Courses.FirstOrDefault(c => c.Id == id);
            course.IsDeleted = true;
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }
    }
}