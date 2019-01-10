using System.IO;
using System;
using LVT.LVT.Services;
using LVT.Classes;
using LVT.LVT.Interfaces;

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
            //string filename = args.Length == 0 ? null : args[0];

            //Validate.ValidateArgument(filename);
            StreamReader file = File.OpenText(args[0]);
            JsonParser Parser = new JsonParser();
            var LVT = Parser.ParseJsonLVTFromStream(file);


            Console.WriteLine(LVT.Vision.ContentLineOne);
            Console.WriteLine(LVT.Vision.Type);

            var subnodes = LVT.Vision.Subnodes;
            Console.WriteLine(subnodes);
            Console.WriteLine(subnodes.Count);
            Console.WriteLine(subnodes.GetType());



            //Console.WriteLine(LVT.Vision.Subnodes);
            //string LVT = ReadAndWrite.BuildTree(file);
            //string FullHTML = ReadAndWrite.CreateFullHTML(LVT);
            //ReadAndWrite.SaveToDisk(FullHTML);
        }

        //public static void RunFromSolution()
        //{
        //    //This takes an absolute path. Copy the full path and file name of your .json file (for example: "C:\temp\Test.json")
        //    StreamReader jsondata = new StreamReader(@"C:\Users\beckerfs\Documents\Projects\LVTWebApp\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
        //    string LVT = ReadAndWrite.BuildTree(jsondata);
        //    string FullHTML = ReadAndWrite.CreateFullHTML(LVT);
        //    ReadAndWrite.SaveToDisk(FullHTML);
        //}
    }
}
