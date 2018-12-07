using CommandLine;
using LVT.LVT.Services;
using System;
using System.IO;

namespace LVT
{
    public class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example!");
                       }
                   });
        }


        //static void Main(string[] args)
        //{
        //    CommandLineParser parser = new CommandLineParser();
        //    //this takes an absolute path and needs to be adapted for each computer depending on where the file lives that you want to open - but this allows you to pass different template trees.
        //    //see Tests for an alternative way that uses project resources instead - so tests can be run no matter on whose environment
        //    StreamReader file = File.OpenText(args[0]);
        //    JsonParser Parser = new JsonParser();
        //    LeanValueTree newTree = Parser.ParseJsonLVTFromStream(file);
        //    //this is an example of what is returned when you access the object:
        //    Console.WriteLine(newTree);
        //    Console.WriteLine(newTree.Vision.Title);
        //    Console.WriteLine(newTree.Vision.Goals[0]);
        //    Console.WriteLine(newTree.Vision.Goals[0].Bets[0]);
        //}
    }
}
