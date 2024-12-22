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
        public ActionResult Index(bool? showActive , bool? showDeleted)
        {
            var students = _managementContext.Students.AsQueryable();
            if(showActive == true && showDeleted == true)
                {
                
                }

            else if(showActive==true)
                {
                students = students.Where(s => !s.IsDeleted);
                }
            else if(showDeleted == true)
                {
                students = students.Where(s => s.IsDeleted);
                }
            else
                {
                students = students.Where(s => !s.IsDeleted);
                }
            //var student = _managementContext.Students.Where(s => !s.IsDeleted).ToList();
            return View(students.ToList());
        }

        //public ActionResult GetStudent()
        //{
        //    var student = _managementContext.Students.Where(s=> !s.IsDeleted).ToList();
        //    return View(student);
        //}

        public ActionResult ViewStudent(int id)
        {
            var student = _managementContext.Students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }


        //Add Student
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
            return RedirectToAction("Index");
        }

        //Update Student
        //Removed Attribute
        public ActionResult Update(int id)
            {
            var student = _managementContext.Students.FirstOrDefault(s => s.Id == id);
            if(student == null)
                {
                return HttpNotFound();
                }
            return View(student);
            }

        [HttpPost]
        public ActionResult Update(Student student)
            {
            var entry = _managementContext.Entry(student);
            entry.State = System.Data.Entity.EntityState.Modified;
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }

        //Delete Student
        //Removed Attribute
        public ActionResult Delete(int id)
            {
            var student = _managementContext.Students.Find(id);
            if(student == null)
                {
                return HttpNotFound();
                }
            student.IsDeleted = true;
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }

        //Get Delete Student List
        //[HttpGet]
        //public ActionResult DeletedList()
        //    {
        //    var deletedStudent = _managementContext.Students.Where(d => d.IsDeleted).ToList();
        //    return View(deletedStudent);
        //    }

        //Restore Deleted Student
         public ActionResult RestoreStudent(Student student)
            {
            var restoreStudent = _managementContext.Students.FirstOrDefault(s => s.Id == student.Id);
            restoreStudent.IsDeleted = false;
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }
    }
}