using System;
using System.Collections.Generic;
using SalaryMgr.Model;

namespace SalaryMgr.Service
{
    public class DefaultPayslipGenerator : IPayslipGenerator
    {
        private const int MONTHS_IN_A_YEAR = 12;

        public Payslip Generate(Employee employee)
        {
            var rules = TaxRule.LoadRules();

            return Process(employee, rules);
        }

        /*Notes: All calculation results should be rounded to the whole dollar. 
        If >= 50 cents round up to the next dollar increment, otherwise round down.
        */

        public static decimal SalaryRound(decimal val)
        {
            return Math.Round(val, MidpointRounding.AwayFromZero);
        }

        private Payslip Process(Employee employee, List<TaxRule> rules)
        {
            var ps = new Payslip();

            ps.GrossIncome = SalaryRound(employee.Salary/MONTHS_IN_A_YEAR);

            foreach (var rule in rules)
            {
                if (rule.TaxBracketMax.HasValue)
                {
                    if (employee.Salary >= rule.TaxBracketMin && employee.Salary <= rule.TaxBracketMax.Value)
                    {
                        ps.IncomeTax =
                            SalaryRound((rule.BaseTaxAmount + (employee.Salary - rule.TaxBracketMin)*rule.ExcessAmount)/
                                        MONTHS_IN_A_YEAR);
                        break;
                    }
                }
            }

            ps.NetIncome = ps.GrossIncome - ps.IncomeTax;
            ps.Super = SalaryRound(ps.GrossIncome*employee.SuperRate/100);
            return ps;
        }
    }
}