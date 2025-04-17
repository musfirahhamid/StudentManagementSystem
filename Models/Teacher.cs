using StudentManagementSystem.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Teacher:Common
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }

        public int? SessionId { get; set; }
        public Session Session { get; set; }

        public int? CourseId { get; set; }
        public Session Course { get; set; }
        }
}