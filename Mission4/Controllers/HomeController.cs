using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FormContext _blahContext { get; set; }

        public HomeController(ILogger<HomeController> logger, FormContext someName)
        {
            _logger = logger;
            _blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = _blahContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Form(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                _blahContext.Add(ar);
                _blahContext.SaveChanges();

                return View("Confirmation",ar);
            }
            else // If invalid
            {
                ViewBag.Categories = _blahContext.Categories.ToList();
                return View(ar);
            }


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MovieList ()
        {
            var movie = _blahContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.CategoryId)
                .ToList();
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = _blahContext.Categories.ToList();

            var movie = _blahContext.responses.Single(x => x.MovieId == movieid);

            return View("Form", movie);
        }

        [HttpPost]
        public IActionResult Edit (ApplicationResponse blah)
        {
            _blahContext.Update(blah);
            _blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _blahContext.responses.Single(x => x.MovieId == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            _blahContext.responses.Remove(ar);
            _blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
