using System.IO;

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
                StreamReader file = File.OpenText(args[0]);
                LeanValueTree newTree = ReadAndWrite.ParseLVTData(file);
                ReadAndWrite.CreateLVTHtml(newTree);
            }
            else
            {
                ReadAndWrite.ShowErrorMessage(args);
            }
        }

        public static void RunFromSolution()
        {
            //this takes an absolute path and needs to be adapted for each computer depending on where the file lives that you want to open - but this allows you to pass different template trees.
            //StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
            StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\TwoGoalsTwoBetsLVT.json");
            LeanValueTree newTree = ReadAndWrite.ParseLVTData(file);
            ReadAndWrite.CreateLVTHtml(newTree);
        }
    }
}
