using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentAPI.Models
{
    public class Employee
    {
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? JoiningDate { get; set; }
        public decimal? PreviousExperince { get; set; }
        public decimal? Salary { get; set; }
        public string Address { get; set; }
    }
}