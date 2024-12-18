﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Display( Name = "Department Name")]
        public string DepartmentName { get; set; }

        public bool IsDeleted { get; set; }
    }
}