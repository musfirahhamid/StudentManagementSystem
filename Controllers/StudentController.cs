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
        public ActionResult Index(string showFilter, string searchTerm, int page = 1)
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

            // Apply search filter
            if(!string.IsNullOrEmpty(searchTerm))
                {
                student = student.Where(s => s.FirstName.Contains(searchTerm) || s.LastName.Contains(searchTerm));
                }

            // Pagination logic
            int pageSize = 10;
            student = student.OrderByDescending(s => s.CreatedDate);
            int totalRecords = student.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            student = student.Skip((page - 1) * pageSize).Take(pageSize);

            // Pass data to view
            ViewBag.ShowActive = showFilter != "deleted";
            ViewBag.ShowDeleted = showFilter == "deleted";
            ViewBag.SearchTerm = searchTerm;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

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
            if(!ModelState.IsValid)
                {
                return View(model); // Return view with validation errors
                }

            genericRepository.Insert(model);
            model.CreatedDate = DateTime.UtcNow;
            model.UpdatedDate = DateTime.UtcNow;
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
            if(!ModelState.IsValid)
                {
                return View(model); // Return view with validation errors
                }

            // Fetch the existing student from the database
            var existingStudent = genericRepository.GetById(model.Id);
            if(existingStudent == null)
                {
                return HttpNotFound();
                }

            // Use reflection to copy properties from model to existingStudent
            foreach(var property in typeof(Student).GetProperties())
                {
                // Ensure we don't update CreatedDate or any other properties you want to preserve
                if(property.Name != "CreatedDate" && property.CanWrite)
                    {
                    var value = property.GetValue(model);
                    property.SetValue(existingStudent, value); // Set value on existingStudent, not model
                    }
                }

            // Set UpdatedDate to current time
            existingStudent.UpdatedDate = DateTime.UtcNow;

            // Save the changes to the database
            genericRepository.Save();

            // Redirect to the Index page to view the updated list
            return RedirectToAction("Index", "Student");
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