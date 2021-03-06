﻿using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LVT.web.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using LVT.LVT.Services;

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
            string FullHTML;

            try
            {
                Validate.ValidateFilename(filename);
                StreamReader jsondata = new StreamReader(file.OpenReadStream());
                string LVT = ReadAndWrite.BuildTree(jsondata);
                FullHTML = ReadAndWrite.CreateFullHTML(LVT);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }

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
