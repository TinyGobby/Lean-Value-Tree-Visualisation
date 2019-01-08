using System.IO;
using System;
using System.Runtime.InteropServices;
using LVT.LVT.Services;

namespace LVT
{
    public class Program
    {
        static void Main(string[] args)
        {
            //RunFromSolution();
            try
            {
                RunFromCommandLine(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void RunFromCommandLine(string[] args)
        {
            string filename = args.Length == 0 ? null : args[0];

            Validate.ValidateArgument(filename);
            StreamReader file = File.OpenText(args[0]);
            string LVT = ReadAndWrite.BuildTree(file);
            string FullHTML = ReadAndWrite.CreateFullHTML(LVT);
            ReadAndWrite.SaveToDisk(FullHTML);
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
