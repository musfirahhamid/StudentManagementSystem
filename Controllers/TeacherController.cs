using StudentManagementSystem.DAL;
using StudentManagementSystem.GenericRepository;
using StudentManagementSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
    {
    public class TeacherController : Controller
        {
        //Created a variable to hold the instance of GenericRepository
        private IGenericRepository<Teacher> genericRepository = null;

        //Initializing the genericRepository through a parameterless constructor
        public TeacherController()
            {
            this.genericRepository = new GenericRepository<Teacher>();
            }

        //The following Action Method is used to return all the teacher
        public ActionResult Index(string showFilter)
            {
            if(string.IsNullOrEmpty(showFilter))
                {
                showFilter = "active"; // Default value
                }
            var teacher = genericRepository.GetAllActive().AsQueryable();

            if(showFilter == "deleted")
                {
                teacher = genericRepository.GetAllDeleted().AsQueryable();
                }
            else
                {
                teacher = genericRepository.GetAllActive().AsQueryable();
                }

            // Pass filter values to the view
            ViewBag.ShowActive = showFilter != "deleted";
            ViewBag.ShowDeleted = showFilter == "deleted";

            return View(teacher.ToList());
            }


        //The following Action Method is used to return specific teacher based on id.
        public ActionResult ViewTeacher(int id)
            {
            var teacher = genericRepository.GetById(id);
            return View(teacher);
            }

        //The following Action Method is used to add new record.
        //Validation check needs to be added
        [HttpGet]
        public ActionResult Create()
            {
            return View();
            }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
            {
            genericRepository.Insert(teacher);
            genericRepository.Save();
            return RedirectToAction("Index","Teacher");
            }

        //The following Action Method is used to update existing record.
        [HttpGet]
        public ActionResult Update(int id)
            {
            Teacher teacher = genericRepository.GetById(id);
            return View(teacher);
            }

        [HttpPost]
        public ActionResult Update(Teacher teacher)
            {
            genericRepository.Update(teacher);
            genericRepository.Save();
            return RedirectToAction("Index", "Teacher");
            }

        //The following Action Method is used to delete existing record.
        public ActionResult Delete(int id)
            {
            genericRepository.Delete(id);
            genericRepository.Save();
            TempData["FlashMessage"] = "Deleted successfully.";
            return RedirectToAction("Index", "Teacher", new { showFilter = "active" });
            }

        //The following Action Method is used to get all deleted record.
        public ActionResult DeletedList()
            {
            var teacher = genericRepository.GetAllDeleted();
            return View(teacher);
            }

        //The following Action Method is used to restore deleted record.
        public ActionResult RestoreTeacher(int id)
            {
            genericRepository.Restore(id);
            genericRepository.Save();
            TempData["FlashMessage"] = "Restored successfully.";
            return RedirectToAction("Index", "Teacher", new { showFilter = "deleted" });
            }
        }
    }