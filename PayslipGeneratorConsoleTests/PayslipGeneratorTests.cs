using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayslipGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipGenerator.Tests
{
    [TestClass()]
    public class PayslipGeneratorTests
    {
          
        [TestMethod()]
        public void ProcessedRecordTest()
        {
            PayslipGenerator pg = new PayslipGenerator();
            pg.ReadFromFile("import/test1.csv");
            pg.Process();
            Assert.AreEqual(2, pg.GetProcessedRecordCount());            
        }

        [TestMethod()]
        public void ReadFromFileTest()
        {
            PayslipGenerator pg = new PayslipGenerator();
            pg.ReadFromFile("import/test1.csv");
            Assert.AreEqual(2,pg.GetReadRecordCount());
        }
    }
}