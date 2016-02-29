namespace SalaryMgr.Model
{
    public class Payslip
    {
        public decimal GrossIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public string Name { get; set; }
        public decimal NetIncome { get; set; }
        public string PayPeriod { get; set; }
        public decimal Super { get; set; }
    }
}