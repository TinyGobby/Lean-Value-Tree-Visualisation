using LVT.LVT.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LVT
{
    public class Program
    {
        static void Main(string[] args)
        {
            //this takes an absolute path and needs to be adapted for each computer depending on where the file lives that you want to open - but this allows you to pass different template trees.
            //see Tests for an alternative way that uses project resources instead - so tests can be run no matter on whose environment
            //StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
            StreamReader file = File.OpenText(@"C:\Users\jeffervl\source\repos\Lean-Value-Tree-Visualisation\LVT\TwoGoalsTwoBetsLVT.json");
            JsonParser Parser = new JsonParser();
            LeanValueTree newTree = Parser.ParseJsonLVTFromStream(file);
            VisionPresenter VP = new VisionPresenter();
            string OrgaChart = VP.VisualizeToString(newTree.Vision);
            
            Console.WriteLine(OrgaChart);

            // this needs to be moved to separate function

            Directory.CreateDirectory("C:\\temp");
            string content = Properties.Resources.TemplatePart1 + OrgaChart + Properties.Resources.TemplatePart2;
            File.WriteAllText(@"C:\temp\LVT.html", content);
            Console.WriteLine(@"Your tree has been saved to C:\temp\LVT.html");

            //this is an example of what is returned when you access the object:
            //Console.WriteLine(newTree);
            //Console.WriteLine(newTree.Vision.Title);
            //Console.WriteLine(newTree.Vision.Goals[0]);
            //Console.WriteLine(newTree.Vision.Goals[0].Bets[0]);
        }
    }
}
