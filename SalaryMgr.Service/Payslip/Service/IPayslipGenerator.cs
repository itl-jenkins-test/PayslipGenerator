using SalaryMgr.Model;
using System.Collections.Generic;

namespace SalaryMgr.Service
{
    public interface IPayslipGenerator
    {
        Payslip Generate(Employee employee);
        List<Payslip> Generate(List<Employee> employee);
    }
}