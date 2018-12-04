using LVT.LVT.Services;
using System.IO;

namespace LVT
{
    public class Program
    {

        static void Main(string[] args)
        {
            //StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
            //JsonParser Parser = new JsonParser();
            //LeanValueTree newTree = Parser.ParseJsonLVTFromStream(file);
            Measure test = new Measure("blah", "blub", 3, "blib");
            System.Console.WriteLine(test.Amount);
            System.Console.WriteLine(test.Deadline);
            System.Console.WriteLine(test.Units);
        }
    }
}
