using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core_NewServie.Models
{
    public class Department
    {
        [Key] // Primary Identity Key 
        public int DeptNo { get; set; }
        [Required]
        [StringLength(200)]
        public string DeptName { get; set; }
        [Required]
        [StringLength(200)]
        public string Location { get; set; }
        [Required]
        public int Capacity { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        [Required]
        [StringLength(200)]
        public string EmpName { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int DeptNo { get; set; }
        [Required]
        [StringLength(200)]
        public string Designation { get; set; }
        public Department Department { get; set; }
    }
}
