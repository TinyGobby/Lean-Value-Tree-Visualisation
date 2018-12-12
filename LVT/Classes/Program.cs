using LVT.LVT.Interfaces;
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
            //will no longer be an issue when we start the program from the command line with the file location as argument
            //StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
            StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\TwoGoalsTwoBetsLVT.json");
            LeanValueTree newTree = ParseLVTData(file);
            CreateLVTHtml(newTree);
        }

        // the below should probably be moved to services

        public static LeanValueTree ParseLVTData(StreamReader file)
        {
            JsonParser Parser = new JsonParser();
            return Parser.ParseJsonLVTFromStream(file);
        }

        public static void CreateLVTHtml(LeanValueTree tree)
        {   // this had to be added because we decided to inject the dependencies into each class for testing
            EpicPresenter EP = new EpicPresenter();
            MeasurePresenter MP = new MeasurePresenter();
            InitiativePresenter IP = new InitiativePresenter(EP, MP);
            BetPresenter BP = new BetPresenter(IP);
            GoalPresenter GP = new GoalPresenter(BP);
            VisionPresenter VP = new VisionPresenter(GP);

            Directory.CreateDirectory("C:\\temp");
            string OrgaChart = VP.VisualizeToString(tree.Vision);
            SaveToDisk(OrgaChart);
        }

        public static void SaveToDisk(string chartdata)
        {
            string content = Properties.Resources.TemplateHTMLHeader + chartdata + Properties.Resources.TemplateHTMLFooter;
            File.WriteAllText(@"C:\temp\LVT.html", content);
            Console.WriteLine(@"Your tree has been saved to C:\temp\LVT.html");
        }
    }
}
