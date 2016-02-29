using System;
using SalaryMgr.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryMgr.ModelTests
{
    [TestClass]
    public class EmployeeValidationUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "First Name must be provided")]
        public void NameValidationTest()
        {
            Employee emp = new Employee("", "", 1000, 9.0m, "2012 - 03 - 01", "2012 - 03 - 30");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Salary is a positive value")]
        public void SalaryValidationTest()
        {
            Employee emp = new Employee("Mathew", "Joseph", -1000, 9.0m, "2012 - 03 - 01", "2012 - 03 - 30");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Super Rate value must be between 0 and 50 both inclusive")]
        public void RateNegativeValidationTest()
        {
            Employee emp = new Employee("Mathew", "Joseph", 1000, -9.0m, "2012 - 03 - 01", "2012 - 03 - 30");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Super Rate value must be between 0 and 50 both inclusive")]
        public void RateOutOfRangeValidationTest()
        {
            Employee emp = new Employee("Mathew", "Joseph", 1000, 51, "2012-03-01", "2012-03-30");

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException),
            "Start Date format should be of type yyyy-mm-dd")]
        public void DateInvalidFormatValidationTest()
        {
            Employee emp = new Employee("Mathew", "Joseph", 1000, 9.0m, "2012  - 01", "2012-03-30");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "End Date has to be greater than Start Date")]
        public void DateEndDateGreaterThanStartDateValidationTest()
        {
            Employee emp = new Employee("Mathew", "Joseph", 1000, 9.0m, "2012-10-01", "2012-03-30");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Start Date must be provided and in the format yyyy-mm-dd")]
        public void DateMissingValidationTest()
        {
            Employee emp = new Employee("Mathew", "Joseph", 1000, 9.0m, "", "2012-03-30");
        }
    }
}
