using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryMgr.Service
{
    //TODO hook this up to a dependency injection framework
    public class ServiceProvider
    {
        public static IPayslipCalculator GetPayslipCalculator()
        {
            return new DefaultPayslipCalculatorImpl();
        }

        public static IPayslipGenerator GetPayslipGenerator()
        {
            return new DefaultPayslipGeneratorImpl();
        }
        
    }
}
