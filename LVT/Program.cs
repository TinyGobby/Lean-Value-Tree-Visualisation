using LVT.LVT.Services;
using System;
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

        // the below should probably be moved to services
      
        public static void RunFromCommandLine(string[] args)
        {
            CommandLineArg argsList = new CommandLineArg();
            argsList.CheckCommandLineArgument(args);
          
            StreamReader file = File.OpenText(args[0]);
            LeanValueTree newTree = ParseLVTData(file);
            CreateLVTHtml(newTree);
        }

        public static void RunFromSolution()
        {
            //this takes an absolute path and needs to be adapted for each computer depending on where the file lives that you want to open - but this allows you to pass different template trees.
            //StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\SingleBranchLVT.json");
            StreamReader file = File.OpenText(@"C:\Users\beckerfs\Documents\Projects\LVT\Lean-Value-Tree-Visualisation\LVT\TwoGoalsTwoBetsLVT.json");
            LeanValueTree newTree = ParseLVTData(file);
            CreateLVTHtml(newTree);
        }

        public static LeanValueTree ParseLVTData(StreamReader file)
        {
            JsonParser Parser = new JsonParser();
            return Parser.ParseJsonLVTFromStream(file);
        }

        public static void CreateLVTHtml(LeanValueTree tree)
        { 
            VisionPresenter VP = new VisionPresenter();

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
