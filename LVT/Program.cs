using LVT.LVT.Services;
using System.IO;

namespace LVT
{
    public class Program
    {

        static void Main(string[] args)
        {
            StreamReader file = File.OpenText(@"C:\Users\patils3\source\repos\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
            JsonParser Parser = new JsonParser();
            LeanValueTree newTree = Parser.ParseJsonLVTFromStream(file);  
        }
    }
}
