using LVT.LVT.Services;
using LVT.LVT.Interfaces;
using System;
using System.IO;

namespace LVT
{
    public class ReadAndWrite 
    {
        public static string BuildTree(StreamReader file)
        {
            LeanValueTree newTree = ParseLVTData(file);
            return CreateLVTHtml(newTree);
        }

        internal static LeanValueTree ParseLVTData(StreamReader file)
        {
            JsonParser Parser = new JsonParser();
            return Parser.ParseJsonLVTFromStream(file);
        }

        internal static string CreateLVTHtml(LeanValueTree tree)
        {
            VisionPresenter VP = new VisionPresenter();

            Directory.CreateDirectory("C:\\temp");
            return VP.VisualizeToString(tree.Vision);
        }

        public static string CreateFullHTML(string LVTHTMLString)
        {
            return Properties.Resources.TemplateHTMLPageTop + LVTHTMLString + Properties.Resources.TemplateHTMLPageBottom;
        }

        internal static void SaveToDisk(string content)
        {
            File.WriteAllText(@"C:\temp\LVT.html", content);
            Console.WriteLine(@"Your LeanValueTree has been saved to C:\temp\LVT.html");
        }
    }
}
