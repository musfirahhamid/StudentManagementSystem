using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        //dependency injection
        private readonly ManagementContext _managementContext;
        public DepartmentController()
            {
            _managementContext = new ManagementContext();
            }
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

      //Add Department
      [HttpGet]
      public ActionResult GetDepartment()
            {
            var department = _managementContext.Departments.Where(d => !d.IsDeleted).ToList();
            return View(department);
            }

      //View Department Details
      [HttpGet]
      public ActionResult ViewDetails(int id)
            {
            var department = _managementContext.Departments.FirstOrDefault(d=>d.Id==id);
            return View(department);
            }

        //Create Department
        [HttpGet]
        public ActionResult Create()
            {
            return View();
            }

        [HttpPost]
        public ActionResult Create(Department department)
            {
            _managementContext.Departments.Add(department);
            _managementContext.SaveChanges();
            return RedirectToAction("GetDepartment");
            }

        //Update Department
        [HttpGet]
        public ActionResult Update(int id)
            {
            var department = _managementContext.Departments.FirstOrDefault(s => s.Id == id);
            if(department == null)
                {
                return HttpNotFound();
                }
            return View(department);
            }

        [HttpPost]
        public ActionResult Update(Department department)
            {
            var dep = _managementContext.Entry(department);
            dep.State = System.Data.Entity.EntityState.Modified;
            _managementContext.SaveChanges();
            return RedirectToAction("GetDepartment");
            }

        //Delete Department
        [HttpGet]
        public ActionResult Delete(int id)
            {
            var dep = _managementContext.Departments.Find(id);
            dep.IsDeleted = true;
            _managementContext.SaveChanges();
            return RedirectToAction("GetDepartment");
            }
    }
}