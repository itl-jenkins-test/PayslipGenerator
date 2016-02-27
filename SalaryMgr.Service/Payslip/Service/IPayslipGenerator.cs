using SalaryMgr.Model;

namespace SalaryMgr.Service
{
    public interface IPayslipGenerator
    {
        Payslip Generate(Employee employee);
    }
}