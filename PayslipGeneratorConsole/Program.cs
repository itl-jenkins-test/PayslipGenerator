using System;
using CommandLine;
using CommandLine.Text;
using SalaryMgr.Service;

namespace PayslipGenerator
{
    // Define a class to receive parsed values
    class Options
    {
        [Option('i', "input", Required = true,
          HelpText = "Input mode. Options console|file")]
        public string InputMode { get; set; }

        [Option('s', "inputfile", Required = false,
          HelpText = "Provide the name of the file containing employee records. CSV file")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = true,
          HelpText = "Output mode. Options console|file")]
        public string OutputMode { get; set; }

        [Option('t', "outputfile", Required = false,DefaultValue ="N", 
          HelpText = "Provide the name of the file for the payslip records")]
        public string OutputFile { get; set; }

        //TODO can trap this statement to display logging
        [Option('v', "verbose", DefaultValue = false,
          HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {

            var options = new Options();
            IPayslipGenerator pg = ServiceProvider.GetPayslipGenerator();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                // Values are available here
                if (options.Verbose)
                {
                    Console.WriteLine($"Input Mode: {options.InputMode}");
                    Console.WriteLine($"Input File: {options.InputFile}");
                    Console.WriteLine($"Output Mode: {options.OutputFile}");
                    Console.WriteLine($"Output File: {options.OutputMode}");
                }

                //TODO Could do with better validation around the input parameters. 
                if (options.InputMode.ToLower().Equals("console"))
                {
                    pg.ReadFromConsole();
                }
                if (options.InputMode.ToLower().Equals("file"))
                {
                    if (!String.IsNullOrEmpty(options.InputFile))
                        pg.ReadFromFile(options.InputFile);
                }

                pg.Process();

                if (pg.GetPayslipsGeneratedCount() > 0)
                {
                    if (options.OutputMode.ToLower().Equals("console"))
                    {
                        pg.WriteToConsole();
                    }
                    if (options.OutputMode.ToLower().Equals("file"))
                    {
                        if (!String.IsNullOrEmpty(options.OutputFile))
                            pg.WriteToFile(options.OutputFile);
                    }
                }

            }
        }

        
    }
}