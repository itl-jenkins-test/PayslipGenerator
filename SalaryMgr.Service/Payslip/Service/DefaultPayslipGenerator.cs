using System;
using System.Collections.Generic;
using SalaryMgr.Model;

namespace SalaryMgr.Service
{
    public class DefaultPayslipGenerator : IPayslipGenerator
    {
        private const int MonthsInAYear = 12;

        public Payslip Generate(Employee employee)
        {
            
            //TODO Have to refactor this later to prevent the rules from being loaded multiple times.
            var rules = TaxRule.LoadRules();

            foreach (var rule in rules)
            {
                if (employee.Salary >= rule.TaxBracketMin)
                {
                    /*There will be one rule with no TaxBracketMax*/
                    if (rule.TaxBracketMax.HasValue)
                    {
                        if (employee.Salary <= rule.TaxBracketMax.Value)
                            return CalculateIncome(employee, rule);
                    }
                    else
                        return CalculateIncome(employee, rule);
                }
            }

            return null;
        }

        /*Notes: All calculation results should be rounded to the whole dollar. 
        If >= 50 cents round up to the next dollar increment, otherwise round down.

            This method has been separated so that the RoundingMechanism is consistent throughout our calculations.
        */
        public static decimal SalaryRound(decimal val)
        {
            return Math.Round(val, MidpointRounding.AwayFromZero);
        }
       

        /*Can make all calculations in one method*/
        private Payslip CalculateIncome(Employee employee, TaxRule rule)
        {
            Payslip ps = new Payslip();
            ps.GrossIncome = SalaryRound(employee.Salary / MonthsInAYear);
            ps.Super = SalaryRound(ps.GrossIncome * employee.SuperRate / 100);
            ps.IncomeTax = SalaryRound((rule.BaseTaxAmount + (employee.Salary - rule.TaxBracketMin) * rule.ExcessAmount) /
                               MonthsInAYear);
            ps.NetIncome = ps.GrossIncome - ps.IncomeTax;
            return ps;
        }
        
    }
}