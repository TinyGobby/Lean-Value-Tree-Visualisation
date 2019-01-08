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
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using LVT.LVT.Services;
using System.Net.Http;
using System.Threading;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

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
            string filename = file?.FileName;

            try
            {
                Validate.ValidateFile(filename);
                StreamReader jsondata = new StreamReader(file.OpenReadStream());
                string LVT = ReadAndWrite.BuildTree(jsondata);
                string FullHTML = ReadAndWrite.CreateFullHTML(LVT);

                return Content(FullHTML, "text/html"); ;
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
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
