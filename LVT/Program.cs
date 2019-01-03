using System.IO;
using System;

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
            if (ReadAndWrite.IsValidArgument(args))
            {
                Console.WriteLine($"Processing {args[0]}");
                StreamReader file = File.OpenText(args[0]);
                ReadAndWrite.BuildTree(file);
            }
            else
            {
                ReadAndWrite.ShowErrorMessage(args);
            }
        }

        public static void RunFromSolution()
        {
            //This takes an absolute path. Copy the full path and file name of your .json file (for example: "C:\temp\Test.json")
            //StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
            StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\TwoGoalsTwoBetsLVT.json");
            ReadAndWrite.BuildTree(file);
        }
    }
}
