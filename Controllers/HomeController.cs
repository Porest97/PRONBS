using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PRONBS.Models;

namespace PRONBS.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Accounting()
        {
            return View();
        }

        public IActionResult Quotations()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Incidents()
        {
            return View();
        }

        public IActionResult Reporting()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        public IActionResult Mobile()
        {
            return View();
        }

        public IActionResult Prospecting()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult TestModels()
        {
            return View();
        }

        //Settings menu !
        public IActionResult Settings()
        {
            return View();
        }
        // SRHL IT LAB !
        public IActionResult LAB()
        {
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
