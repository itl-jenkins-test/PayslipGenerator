using System;
using CommandLine;
using CommandLine.Text;
using SalaryMgr.Model;
using SalaryMgr.Service;

namespace PayslipGenerator
{
    // Define a class to receive parsed values
    class Options
    {
        [Option('i', "input", Required = true,
          HelpText = "Input mode")]
        public string InputMode { get; set; }

        [Option('s', "inputfile", Required = false,
          HelpText = "Input file")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = true,
          HelpText = "Output mode")]
        public string OutputMode { get; set; }

        [Option('t', "outputfile", Required = false,DefaultValue ="N", 
          HelpText = "Output file")]
        public string OutputFile { get; set; }

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
            PayslipGenerator pg = new PayslipGenerator();

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

                if (options.InputMode.CompareTo("manual") == 0)
                {
                    pg.ReadFromConsole();
                }
                if (options.InputMode.CompareTo("file") == 0)
                {
                    if (!String.IsNullOrEmpty(options.InputFile))
                        pg.ReadFromFile(options.InputFile);
                }
                pg.Process();
                if (options.OutputMode.CompareTo("console") == 0)
                {
                    pg.WriteToConsole();
                }
                if (options.OutputMode.CompareTo("file") == 0)
                {
                    if (!String.IsNullOrEmpty(options.OutputFile))
                        pg.WriteToFile(options.OutputFile);
                }

            }
        }

        
    }
}