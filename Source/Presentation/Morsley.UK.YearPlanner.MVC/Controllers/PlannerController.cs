using Microsoft.AspNetCore.Mvc;
using Morsley.UK.YearPlanner.Domain.Models;
using Morsley.UK.YearPlanner.MVC.Models;
using Morsley.UK.YearPlanner.MVC.ViewModels;
using System;
using System.Diagnostics;

namespace Morsley.UK.YearPlanner.MVC.Controllers
{
    public class PlannerController : Controller
    {
        public IActionResult Year(int? value)
        {
            if (value is null)
            {
                var now = DateTime.UtcNow;
                value = now.Year;
            }

            var year = new Year((int)value);
            var yearPlannerViewModel = new YearPlannerViewModel(year);

            return View(yearPlannerViewModel);
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