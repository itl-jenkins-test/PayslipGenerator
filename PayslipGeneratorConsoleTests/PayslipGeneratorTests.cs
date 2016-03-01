using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryMgr.Service;

namespace PayslipGeneratorConsoleTests
{
    [TestClass()]
    [DeploymentItem("import", "import")]
    [DeploymentItem("output", "output")]
    public class PayslipGeneratorTests
    {          
        [TestMethod()]        
        public void ProcessedRecordTest()
        {
            IPayslipGenerator pg = ServiceProvider.GetPayslipGenerator();
            pg.ReadFromFile("import/test1.csv");
            pg.Process();
            Assert.AreEqual(2, pg.GetPayslipsGeneratedCount());            
        }

        [TestMethod()]        
        public void ReadFromFileTest()
        {
            IPayslipGenerator pg = ServiceProvider.GetPayslipGenerator();
            pg.ReadFromFile("import/test1.csv");
            Assert.AreEqual(2,pg.GetEmployeeRecordsLoadedCount());
        }
    }
}