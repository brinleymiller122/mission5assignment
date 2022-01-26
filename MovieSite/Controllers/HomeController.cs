using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieFormsContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieFormsContext mfc)
        {
            _logger = logger;
            movieContext = mfc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]

        
        public IActionResult MovieForm(MovieModel mm)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(mm);
                movieContext.SaveChanges();
                return View("Confirmation", mm);
            }
            else
            {
                return View(mm);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
