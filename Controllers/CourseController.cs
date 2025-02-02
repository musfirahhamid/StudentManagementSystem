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
        public ActionResult Index(bool? showActive , bool? showDeleted)
        {
            var course = _managementContext.Courses.AsQueryable();
            if(showActive == true && showDeleted == true)
                {

                }
            else if(showActive == true)
                {
                course = course.Where(c => !c.IsDeleted);
                }
            else if(showDeleted==true)
                {
                course = course.Where(c => c.IsDeleted);
                }
            else
                {
                course = course.Where(c => !c.IsDeleted);
                }
            
            return View(course.ToList());
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
           var existingCourse = _managementContext.Courses.FirstOrDefault(c=>c.CourseCode== course.CourseCode && c.IsDeleted==false);
            if(existingCourse != null)
                {
                ViewBag.Message = "CourseCode already exists";
                return View();
                }
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

        //Delete Course
        public ActionResult Delete(int id)
            {
            var course = _managementContext.Courses.FirstOrDefault(c => c.Id == id);
            course.IsDeleted = true;
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }

        //Restore Course
        public ActionResult Restore(int id)
            {
            var course = _managementContext.Courses.FirstOrDefault(c => c.Id == id);
            course.IsDeleted = false;
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }

        //Restore COurse List
        public ActionResult RestoreList()
            {
            var course=_managementContext.Courses.Where(c => c.IsDeleted).ToList();
            return View(course);
            }
    }
}