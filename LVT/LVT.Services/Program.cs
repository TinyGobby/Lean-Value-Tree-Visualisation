using System.IO;
using System;
using LVT.LVT.Services;

namespace LVT
{
    public class Program
    {
        static void Main(string[] args)
        {
            //RunFromSolution();
            RunFromCommandLine(args);
        }

        public static void RunFromCommandLine(string[] args)
        {
            if (Validate.IsValidArgument(args))
            {
                Console.WriteLine($"Processing {args[0]}");
                StreamReader file = File.OpenText(args[0]);
                string LVT = ReadAndWrite.BuildTree(file);
                string FullHTML = ReadAndWrite.CreateFullHTML(LVT);
                ReadAndWrite.SaveToDisk(FullHTML);
            }
            else
            {
                Validate.ShowErrorMessage(args);
            }
        }

        public static void RunFromSolution()
        {
            //This takes an absolute path. Copy the full path and file name of your .json file (for example: "C:\temp\Test.json")
            StreamReader jsondata = new StreamReader(@"C:\Users\beckerfs\Documents\Projects\LVTWebApp\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
            string LVT = ReadAndWrite.BuildTree(jsondata);
            string FullHTML = ReadAndWrite.CreateFullHTML(LVT);
            ReadAndWrite.SaveToDisk(FullHTML);
        }
    }
}
