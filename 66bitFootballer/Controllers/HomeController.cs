using _66bitFootballer.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _66bitFootballer.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.Teams.GetAll());
        }

        [HttpPost]
        public IActionResult SaveItem(Footballer footballer, string teamName)
        {
            var team = dataManager.Teams.Get(e => e.Name.Equals(teamName)).FirstOrDefault();
            int teamId;
            if (team is null)
                teamId = dataManager.Teams.Add(new Team() { Name = teamName });
            else teamId = team.Id;
            footballer.TeamId = teamId;

            dataManager.Footballers.Add(footballer);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
