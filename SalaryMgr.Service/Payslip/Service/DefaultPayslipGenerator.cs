using System;
using System.Collections.Generic;
using SalaryMgr.Model;

namespace SalaryMgr.Service
{
    public class DefaultPayslipGenerator : IPayslipGenerator
    {
        private const int MonthsInAYear = 12;

        private List<TaxRule> rules;

        //Provide constructor chaining to allow for the Default constructor to load the static rules
        public DefaultPayslipGenerator(): this(TaxRule.LoadRules())
        {
            
        }

        //Loaded once when the Generator is created.
        //Now supports custom rules being provided
        public DefaultPayslipGenerator(List<TaxRule> rulesToApply)
        {
            if (rulesToApply != null && rulesToApply.Count > 0)
            {
                rules = rulesToApply;
            }            
        }

        /// <summary>
        /// Handles multiple employees. Demonstration of Overloading
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public List<Payslip> Generate(List<Employee> employees)
        {
            List<Payslip> payslips = new List<Payslip>();

            foreach (var emp in employees)
            {
                payslips.Add(Generate(emp));    
            }    
            return payslips;
        }

        public Payslip Generate(Employee employee)
        {                        
            foreach (TaxRule rule in rules)
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
            ps.Name = $"{employee.FirstName} {employee.LastName}";
            ps.PayPeriod = $"{employee.StartDate.Value.ToShortDateString()}={employee.EndDate.Value.ToShortDateString()}";
            ps.GrossIncome = SalaryRound(employee.Salary / MonthsInAYear);
            ps.Super = SalaryRound(ps.GrossIncome * employee.SuperRate.Value / 100);
            ps.IncomeTax = SalaryRound((rule.BaseTaxAmount + (employee.Salary - rule.TaxBracketMin) * rule.ExcessAmount) /
                               MonthsInAYear);
            ps.NetIncome = ps.GrossIncome - ps.IncomeTax;
            return ps;
        }
        
    }
}