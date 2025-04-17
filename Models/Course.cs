using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
    {
    public class Course:Common
        {
      
        [Required]
        [Display(Name ="Course Code")]
        public string CourseCode { get; set; }

        [Required]
        [Display(Name ="Course Name")]
        public string CourseName { get; set; }

        [Display(Name ="Credit Hours")]
        public int CreditHours { get; set; }

        [Display(Name ="Course Status")]
        public string Status { get; set; } // Active, Inactive, Archived

        public int? SessionId { get; set; }
        public Session Session { get; set; }



        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Session> Sessions { get; set; }

        }
    }