using SalaryMgr.Model;
using System.Collections.Generic;

namespace SalaryMgr.Service
{
    /// <summary>
    /// Interface that performs the actual calculation of the payslip from the employee record.
    /// </summary>
    public interface IPayslipCalculator
    {
        Payslip Calculate(Employee employee);
        List<Payslip> Calculate(List<Employee> employee);
    }
}