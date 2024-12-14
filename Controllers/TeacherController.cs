using StudentManagementSystem.DAL;
using StudentManagementSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
    {
    public class TeacherController : Controller
        {
        private  readonly ManagementContext _managementContext;
        public TeacherController()
            {
            _managementContext = new ManagementContext();
            }
        // GET: Teacher
        public ActionResult Index()
            {
            var teacher = _managementContext.Teachers.Where(t => !t.IsDeleted).ToList();
            return View(teacher);
            }

        //public ActionResult GetTeacher()
        //    {
        //    var teacher = _managementContext.Teachers.Where(t=> !t.IsDeleted).ToList();
        //    return View(teacher);
        //    }

        public ActionResult ViewTeacher(int id)
            {
            var teacher = _managementContext.Teachers.FirstOrDefault(t => t.Id == id);
            return View(teacher);
            }


        //Add teacher
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
            return RedirectToAction("Index");
            }

        //Update teacher
        //Removed Attribute
        public ActionResult Update(int id)
            {
            var teacher = _managementContext.Teachers.FirstOrDefault(t=>t.Id==id);
            if(teacher == null)
                {
                return HttpNotFound();
                }
            return View(teacher);
            }

        [HttpPost]
        public ActionResult Update(Teacher teacher)
            {
            var entry = _managementContext.Entry(teacher);
            entry.State = System.Data.Entity.EntityState.Modified;
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }

        //Delete Teacher
        //Removed Attribute
        public ActionResult Delete(int id)
            {
            var teacher = _managementContext.Teachers.Find(id);
            if(teacher == null)
                {
                return HttpNotFound();
                }
            teacher.IsDeleted = true;
            _managementContext.SaveChanges();
            return RedirectToAction("Index");
            }

        }
}