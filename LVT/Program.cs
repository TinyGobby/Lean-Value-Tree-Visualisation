using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace LVT
{
    public class Program
    {

        static void Main(string[] args)
        {
            using (StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                LeanValueTree singleBranchLVT = (LeanValueTree)serializer.Deserialize(file, typeof(LeanValueTree));
                Console.WriteLine(singleBranchLVT.Vision.Title);
                Console.WriteLine(singleBranchLVT.Vision.Goals[1].ToString());
            }
        }
    }
}
