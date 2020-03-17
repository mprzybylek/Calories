using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CaloriesPage.Models;
using CaloriesPage.Database;

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

            //if(!_ctx.Meals.Any())
            //{
            //    Database.Entities.Meal meal = new Database.Entities.Meal
            //    {
            //        Id = 1,
            //        Name = "Bigos"
            //    };

            //    _ctx.Meals.Add(meal);
            //    _ctx.SaveChanges();
            //}
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
    }
}
