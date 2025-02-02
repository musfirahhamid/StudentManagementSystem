using StudentManagementSystem.DAL;
using StudentManagementSystem.GenericRepository;
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
        //Created a variable to hold the instance of GenericRepository
        private IGenericRepository<Student> genericRepository = null;
        //Initializing the genericRepository through a parameterless constructor
        public StudentController()
            {
            this.genericRepository = new GenericRepository<Student>();
            }

        //The following Action Method is used to return all the student
        [HttpGet]
        public ActionResult Index(string showFilter)
            {
            if(string.IsNullOrEmpty(showFilter))
                {
                showFilter = "active"; // Default value
                }
            var student = genericRepository.GetAllActive().AsQueryable();

            if(showFilter == "deleted")
                {
                student = genericRepository.GetAllDeleted().AsQueryable();
                }
            else
                {
                student = genericRepository.GetAllActive().AsQueryable();
                }

            // Pass filter values to the view
            ViewBag.ShowActive = showFilter != "deleted";
            ViewBag.ShowDeleted = showFilter == "deleted";

            return View(student.ToList());
            }

        //The following Action Method is used to return List of All deleted student
        public ActionResult DeletedList()
            {
            var model = genericRepository.GetAllDeleted();
            return View(model);
            }

        //The following action method is used to restore the student
        public ActionResult RestoreStudent(int id)
            {
             genericRepository.Restore(id);
            genericRepository.Save();
            TempData["FlashMessage"] = "Restored successfully.";

            return RedirectToAction("Index", "Student",new {showFilter="deleted" });
            
            }

        //The following Action Method is used to return specific student
        public ActionResult ViewStudent(int id)
            {
            var model = genericRepository.GetById(id);
            return View(model);
            }
        [HttpGet]
        public ActionResult Create()
            {
            return View();
            }

            [HttpPost]
            public ActionResult Create(Student model)
                {
            genericRepository.Insert(model);
            genericRepository.Save();
                    return RedirectToAction("Index", "Student");
                    }
        //The following Action Method will open the Edit Student view based on the StudentId
        [HttpGet]
        public ActionResult Update(int id)
            {
            Student model = genericRepository.GetById(id);
            return View(model);
            }
        //The following Action Method will be called when we  click on the Submit button on the Edit Student view
        [HttpPost]
        public ActionResult Update(Student model)
            {
            genericRepository.Update(model);
            genericRepository.Save();
            return RedirectToAction("Index","Student");
            }

        
        //The following Action Method will be called when you click on the Submit button on the Delete Student view
        public ActionResult Delete(int id)
            {
            genericRepository.Delete(id);
            genericRepository.Save();
            TempData["FlashMessage"] = "Deleted successfully.";

            return RedirectToAction("Index", "Student", new {showFilter="active" });
            }        }
        }