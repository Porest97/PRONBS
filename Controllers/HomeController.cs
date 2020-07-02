using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Accounting()
        {
            return View();
        }
        [Authorize]
        public IActionResult Quotations()
        {
            return View();
        }
        [Authorize]
        public IActionResult Admin()
        {
            return View();
        }
        [Authorize]
        public IActionResult Incidents()
        {
            return View();
        }
        [Authorize]
        public IActionResult Reporting()
        {
            return View();
        }
        [Authorize]
        public IActionResult Links()
        {
            return View();
        }
        [Authorize]
        public IActionResult Mobile()
        {
            return View();
        }
        [Authorize]
        public IActionResult Prospecting()
        {
            return View();
        }
        [Authorize]
        public IActionResult Projects()
        {
            return View();
        }
        [Authorize]
        public IActionResult TestModels()
        {
            return View();
        }
        [Authorize]
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

        // SRHL IT LAB !
        [Authorize]
        public IActionResult NBS()
        {
            return View();
        }
        [Authorize]
        public IActionResult NBS1()
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
