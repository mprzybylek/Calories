using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CaloriesPage.Models;
using CaloriesPage.Database;
using CaloriesPage.Helpers;
using CaloriesPage.Database.Entities;

namespace CaloriesPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CaloriesContext _ctx;

        public HomeController(ILogger<HomeController> logger, CaloriesContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var meals = _ctx.Meals.ToList();

            return View(meals);
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

        public IActionResult Presenter()
        {
            object @presenter = NameGenerator.GeneratePresenter();
            return View(presenter);
        }

        [HttpGet]
        public IActionResult NewMeal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMeal(Meal meal)
        {
            if(!string.IsNullOrEmpty(meal.Name))
            {
                _ctx.Meals.Add(meal);
                _ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewData["ErrorMessage"] = "Value cannot be null or empty";
            }

            return View();
        }

        public IActionResult RemoveMeal(Meal meal)
        {
            if (meal.Name != null)
            {
                var meals = _ctx.Meals.Where(mealRemove => mealRemove.Name == meal.Name);
                if (meals.Any())
                {
                    _ctx.RemoveRange(meals);
                    _ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
