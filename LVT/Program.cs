using LVT.LVT.Services;
using System;
using System.IO;

namespace LVT
{
    public class Program
    {

        static void Main(string[] args)
        {
            StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
            JsonParser Parser = new JsonParser();
            LeanValueTree newTree = Parser.ParseJsonLVTFromStream(file);
            Console.WriteLine(newTree);
            Console.WriteLine(newTree.Vision.Title);
            Console.WriteLine(newTree.Vision.Goals[0]);
            Console.WriteLine(newTree.Vision.Goals[0].Bets[0]);
        }
    }
}
