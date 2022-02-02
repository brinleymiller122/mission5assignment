using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieFormsContext movieContext { get; set; }

        public HomeController(MovieFormsContext mfc)
        {
           
            movieContext = mfc;
        }

        public IActionResult Index()
        {
            return View();
        }

        //My podcasts Action Result
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = movieContext.Category.ToList();
            return View();
        }

        [HttpPost]
        //pass information about movie
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
                ViewBag.Categories = movieContext.Category.ToList();
                return View(mm);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = movieContext.Responses
                .Include(x => x.Category)
                .ToList();
            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Category.ToList();
            var application = movieContext.Responses.Single(x => x.MovieId == movieid);
            return View("MovieForm", application);
        }

        [HttpPost]
        public IActionResult Edit (MovieModel mm)
        {
            movieContext.Update(mm);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var application = movieContext.Responses.Single(x => x.MovieId == movieid);
            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(MovieModel mm)
        {
            movieContext.Responses.Remove(mm);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}


