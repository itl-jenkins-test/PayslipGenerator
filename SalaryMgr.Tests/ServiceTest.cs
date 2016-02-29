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
            IPayslipGenerator pg = new DefaultPayslipGenerator();
            Payslip ps;
            Assert.IsNotNull(
                ps = pg.Generate(new Employee("Mathew", "Joseph", 60050, 9.0m, "2012-03-01", "2012-03-30"))
                )
                ;
            Assert.AreEqual(5004, ps.GrossIncome);
            Assert.AreEqual(922, ps.IncomeTax);
            Assert.AreEqual(450, ps.Super);

        }

        [TestMethod]
        public void MaxSalaryTest()
        {
            IPayslipGenerator pg = new DefaultPayslipGenerator();
            Payslip ps;
            Assert.IsNotNull(
                ps = pg.Generate(new Employee("Mathew", "Joseph", 190000, 9.0m, "2012-03-01", "2012-03-30"))
                )
                ;
            Assert.AreEqual(15833, ps.GrossIncome);
            Assert.AreEqual(1425, ps.Super);
            Assert.AreEqual(4921, ps.IncomeTax);            
        }       
    }
}