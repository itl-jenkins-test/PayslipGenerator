using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryMgr.Model
{
    public class Employee
    {
        public Employee(string firstName, string v2, decimal v3, decimal v4, string startDate, string endDate)
        {
            FirstName = firstName;
            LastName = v2;
            Salary = v3;
            SuperRate = v4;
            StartDate = DateTime.Parse(startDate);
            EndDate = DateTime.Parse(endDate);
        }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        public string FirstName { get; }

        public string LastName { get; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        public decimal Salary { get; }

        [Required]
        [Range(0, 50,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal SuperRate { get; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        public DateTime StartDate { get; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        public DateTime EndDate { get; }
    }
}