using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LVT.web.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Logging;

namespace LVT.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public IActionResult UploadLVTData(IFormFile file)
        {
            StreamReader jsondata = new StreamReader(file.OpenReadStream());
            string LVT = ReadAndWrite.BuildTree(jsondata);
            string FullHTML = ReadAndWrite.CreateFullHTML(LVT);

            //var filePath = Path.GetTempFileName();

            //if (file != null)
            //{
            //    using (stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await file.CopyToAsync(stream);
            //    }
            //    ReadAndWrite.BuildTree();

            //}

            //HtmlContentBuilder builder = new HtmlContentBuilder();
            //var html = builder.AppendHtml(FullHTML);
            return Content(FullHTML, "text/html");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
