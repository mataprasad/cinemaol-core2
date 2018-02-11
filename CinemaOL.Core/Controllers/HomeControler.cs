using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CinemaOL.Services;
using CinemaOL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text;

namespace CinemaOL.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration configuration = null;
        private IHostingEnvironment env = null;
        public HomeController(IConfiguration configuration, IHostingEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
        }

        public string index()
        {
            var a = "";
            a += "" + env.ContentRootPath + Environment.NewLine;
            a += "" + env.WebRootPath + Environment.NewLine;

            foreach (var i in Directory.GetFiles(env.ContentRootPath))
            {
                a += " " + i + Environment.NewLine;
            }

            foreach (var i in Directory.GetDirectories(env.ContentRootPath))
            {
                a += " " + i + Environment.NewLine;
            }

            foreach (var i in Directory.GetFiles(env.ContentRootPath + "/Data"))
            {
                a += " " + i + Environment.NewLine;
            }

            return a;
        }

        public string dir()
        {
            return DirSearch(env.ContentRootPath).ToString();
        }

        private StringBuilder DirSearch(string sDir)
        {
            StringBuilder txt = new StringBuilder();
            try
            {

                foreach (string f in Directory.GetFiles(sDir))
                {
                    txt.AppendLine(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        txt.AppendLine(f);
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                txt.AppendLine(excpt.Message);
            }

            return txt;
        }
    }
}