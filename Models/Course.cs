using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
    {
    public class Course
        {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Course Code")]
        public string CourseCode { get; set; }

        [Required]
        [Display(Name ="Course Name")]
        public string CourseName { get; set; }

        public bool IsDeleted { get; set; }
        }
    }