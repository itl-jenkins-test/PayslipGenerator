using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryMgr.Model;
using SalaryMgr.Service;

namespace SalaryMgr.Tests
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void BasicTest()
        {
            IPayslipCalculator pg = new DefaultPayslipCalculatorImpl();
            Payslip ps;
            Assert.IsNotNull(
                ps = pg.Calculate(new Employee("Mathew", "Joseph", 60050, 9.0m, "2012-03-01", "2012-03-30"))
                )
                ;
            Assert.AreEqual(5004, ps.GrossIncome);
            Assert.AreEqual(922, ps.IncomeTax);
            Assert.AreEqual(450, ps.Super);

        }

        [TestMethod]
        public void MaxSalaryTest()
        {
            IPayslipCalculator pg = new DefaultPayslipCalculatorImpl();
            Payslip ps;
            Assert.IsNotNull(
                ps = pg.Calculate(new Employee("Mathew", "Joseph", 190000, 9.0m, "2012-03-01", "2012-03-30"))
                )
                ;
            Assert.AreEqual(15833, ps.GrossIncome);
            Assert.AreEqual(1425, ps.Super);
            Assert.AreEqual(4921, ps.IncomeTax);            
        }

        [TestMethod]
        public void MultipleEmployeeTest()
        {
            IPayslipCalculator pg = new DefaultPayslipCalculatorImpl();

            Employee emp1 = new Employee("Mathew", "Joseph", 190000, 9.0m, "2012-03-01", "2012-03-30");
            Employee emp2 = new Employee("Mathew", "Joseph", 190000, 9.0m, "2012-03-01", "2012-03-30");
            Employee emp3 = new Employee("Mathew", "Joseph", 190000, 9.0m, "2012-03-01", "2012-03-30");
            Employee emp4 = new Employee("Mathew", "Joseph", 190000, 9.0m, "2012-03-01", "2012-03-30");

            List<Employee> emps = new List<Employee>();
            emps.Add(emp1);
            emps.Add(emp2);
            emps.Add(emp3);
            emps.Add(emp4);

            List<Payslip> resultPayslips = pg.Calculate(emps);

            Assert.AreEqual(4,resultPayslips.Count);          
        }
    }
}