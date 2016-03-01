using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryMgr.Service
{
    /// <summary>
    /// Handles the majority of the actual Payslip Generation ability.
    /// </summary>
    public interface IPayslipGenerator
    {
        int GetEmployeeRecordsLoadedCount();
        int GetPayslipsGeneratedCount();
        void Process();
        void WriteToConsole();
        void ReadFromConsole();
        void WriteToFile(string outputFile);
        void ReadFromFile(string inputFile);
    }
}
