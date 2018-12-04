using Newtonsoft.Json;
using System;
using System.IO;

namespace LVT
{
    public class Program
    {

        static void Main(string[] args)
        {
            ParseJsonLVT();
        }

        public static LeanValueTree ParseJsonLVT()
        {
            LeanValueTree singleBranchLVT;

            using (StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                singleBranchLVT = (LeanValueTree)serializer.Deserialize(file, typeof(LeanValueTree));
            }
            return singleBranchLVT;
        }
    }
}
