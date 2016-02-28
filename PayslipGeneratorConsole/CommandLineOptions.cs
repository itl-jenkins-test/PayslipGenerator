using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipGenerator
{
    class CommandLineOptions
    {        

        [Option('i', "input", Required = true, HelpText = "First Name")]
        public string FirstName { get; set; }

        [Option('i', "input", Required = true, HelpText = "Last Name")]
        public string LastName { get; set; }

        [Option('i', "input", Required = true, HelpText = "Salary")]
        public decimal Salary { get; set; }

        [Option('i', "input", Required = true, HelpText = "Super Rate")]
        public decimal SuperRate { get; set; }

        [Option('i', "input", Required = true, HelpText = "Start Date")]
        public DateTime StartDate { get; set; }

        [Option('i', "input", Required = true, HelpText = "End Date")]
        public DateTime EndDate { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
