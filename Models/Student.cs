﻿using StudentManagementSystem.GenericRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Student:ICommon
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }
     

    }
}