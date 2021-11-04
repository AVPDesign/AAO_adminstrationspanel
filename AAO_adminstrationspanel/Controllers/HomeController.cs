using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AAO_adminstrationspanel.Models;

namespace AAO_adminstrationspanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OpretTur()
        {
            return View();
        }

        public IActionResult AlleTure()
        {
            return View();
        }

        public IActionResult TildelteTure()
        {
            return View();
        }

        public IActionResult AfloserOversigt()
        {
            return View();
        }
    }
}
