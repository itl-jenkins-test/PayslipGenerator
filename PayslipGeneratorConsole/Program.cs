using System;
using CommandLine;
using CommandLine.Text;
using SalaryMgr.Model;
// if you want text formatting helpers (recommended)
using SalaryMgr.Service;

namespace PayslipGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //TODO will have to bring in command line arguments for differentiating between interactive mode and CSV mode
            /*var options = new CommandLineOptions();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
               Console.WriteLine("working ...");
            }
            else
            {
                // Display the default usage information
                Console.WriteLine(options.GetUsage());
            }*/


            //TODO no validations for now. Have to introduce in next iteration.
            Console.Write("First Name:");
            String firstName = Console.ReadLine();

            Console.Write("Last Name:");
            String lastName = Console.ReadLine();

            Console.Write("Annual Salary:");
            String salary = Console.ReadLine();

            Console.Write("Super Rate:");
            String superRate = Console.ReadLine();

            Console.Write("Payment Start Date:");
            String paymentStartDate = Console.ReadLine();

            Console.Write("Payment End Date:");
            String paymentEndDate = Console.ReadLine();

            ProcessCommandLine(firstName, lastName, salary, superRate, paymentStartDate, paymentEndDate);
        }

        //TODO still restricted to a single entry, will have to refactor to allow for multiple entries later
        private static void ProcessCommandLine(string firstName, string lastName, string salary, string superRate,
            string paymentStartDate, string paymentEndDate)
        {
            Employee emp = new Employee(firstName, lastName, Int32.Parse(salary), Decimal.Parse(superRate), paymentStartDate,
                paymentEndDate);

            //TODO Bad design pointing to the only concrete implementation of the IPayslipGenerator. Will have to refactor
            //this out in some iteration
            IPayslipGenerator pg = new DefaultPayslipGenerator();

            Payslip ps = pg.Generate(emp);

            //TODO Have to move this into a Class formatter of sorts with implementations for Screen and CSV
            //TODO this will allow CSV input/output and screen input/output 
            Console.WriteLine($"Name {emp.FirstName} {emp.LastName}");
            Console.WriteLine($"Pay Period {emp.StartDate} {emp.EndDate}");
            Console.WriteLine($"Gross Income {ps.GrossIncome}");
            Console.WriteLine($"Income Tax {ps.IncomeTax}");
            Console.WriteLine($"Net Income {ps.NetIncome}");
            Console.WriteLine($"Super {ps.Super}");

            Console.ReadLine();
        }
    }
}