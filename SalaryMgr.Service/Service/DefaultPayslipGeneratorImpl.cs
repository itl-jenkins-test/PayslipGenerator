using System;
using SalaryMgr.Model;
using SalaryMgr.Service;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace SalaryMgr.Service
{

    public class DefaultPayslipGeneratorImpl : IPayslipGenerator
    {
        //TODO potential impact of List implementation dependning upon the number of records loaded. 
        private List<Employee> _inputEmployees;
        private List<Payslip> _outputPayslips;
        private readonly IPayslipCalculator _payslipCalculator;

        public int GetEmployeeRecordsLoadedCount()
        {
            return (_inputEmployees == null ? 0 : _inputEmployees.Count);            
        }

        public int GetPayslipsGeneratedCount()
        {
            return (_outputPayslips == null ? 0 : _outputPayslips.Count);
        }

        public DefaultPayslipGeneratorImpl()
        {
            _inputEmployees = new List<Employee>();
            _payslipCalculator = ServiceProvider.GetPayslipCalculator();
        }
        
        public void Process()
        {        
            if(GetEmployeeRecordsLoadedCount() > 0)
               _outputPayslips= _payslipCalculator.Calculate(_inputEmployees);          
        }

        public void WriteToConsole()
        {
            
            Console.WriteLine("PROCESSED PAYSLIPS");
            Console.Write("Name\t\t\t");
            Console.Write("Pay Period\t\t\t");
            Console.Write("Gross Income\t");
            Console.Write("Income Tax\t");
            Console.Write("Net Income\t");
            Console.WriteLine("Super\t");
            foreach (var ps in _outputPayslips)
            {
                Console.Write($"{ps.Name}\t");
                Console.Write($"{ps.PayPeriod}\t");
                Console.Write($"{ps.GrossIncome}\t");
                Console.Write($"{ps.IncomeTax}\t");
                Console.Write($"{ps.NetIncome}\t");
                Console.WriteLine($"{ps.Super}");
            }
            Console.WriteLine("Press a key to continue.."); 
            Console.ReadLine();
        }
        

        public void ReadFromConsole()
        {
            char keepGoing;
            do
            {
                //TODO no validations for now. Have to introduce in next iteration.
                Console.WriteLine("Enter Employee Details");
                Console.Write("First Name:");
                string firstName = Console.ReadLine();

                Console.Write("Last Name:");
                string lastName = Console.ReadLine();

                Console.Write("Annual Salary [+ve Integer]:");
                string salary = Console.ReadLine();

                Console.Write("Super Rate [Between 0 and 50 both Inclusive]:");
                string superRate = Console.ReadLine();

                Console.Write("Payment Start Date [yyyy-mm-dd]:");
                string paymentStartDate = Console.ReadLine();

                Console.Write("Payment End Date [yyyy-mm-dd]:");
                string paymentEndDate = Console.ReadLine();

                Console.Write("Continue (Y/N) ?");
                keepGoing = Console.ReadLine().ToUpper()[0];

                Employee emp = new Employee(firstName, lastName, Int32.Parse(salary), Decimal.Parse(superRate), paymentStartDate,paymentEndDate);
                _inputEmployees.Add(emp);

            } while (keepGoing.Equals('Y'));
            
        }

        public void WriteToFile(string outputFile)
        {            
            //TODO can refactor this to remove dependency on CVSHelper
            using (var csv = new CsvWriter(File.CreateText(outputFile)))
            {
                //TODO default mapping causes the output file to be ordered alphabetically by property name
                //TODO will have to change this to an explicit map
                var classmap = csv.Configuration.AutoMap<Payslip>();
                csv.WriteRecords(_outputPayslips);
            }
        }

        public void ReadFromFile(string inputFile)
        {
            //TODO Since the change to CsvHelper forces us to set value through the properties instead of the constructor
            //TODO Should perform a minimal amount of validation here to ensure the CSV file is accurate.
            try
            {
                //TODO can refactor this to remove dependency on CVSHelper
                using (var csv = new CsvReader(File.OpenText(inputFile)))
                {
                    var generatedmap = csv.Configuration.AutoMap<Employee>();
                    _inputEmployees = csv.GetRecords<Employee>().ToList();
                }
            }
            //TODO Should be piped to a logging framework for later
            catch (Exception e)
            {
                Console.WriteLine("Error while reading the source file " + e.Message);
            }
                    
        }
    }
}