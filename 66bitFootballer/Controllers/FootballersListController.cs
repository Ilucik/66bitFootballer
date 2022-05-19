using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _66bitFootballer
{
    public class FootballersListController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IHubContext<SignalServer> signalHub;
        public FootballersListController(DataManager dataManager, IHubContext<SignalServer> signalHub)
        {
            this.dataManager = dataManager;
            this.signalHub = signalHub;
        }
        
        [HttpGet]
        public IActionResult GetFootballers()
        {
            var res = dataManager.Footballers.GetAll().ToList();
            return Ok(res);
        }

        public IActionResult FootballersList()
        {
            IEnumerable<Footballer> footballers = dataManager.Footballers.GetAll();
            return View(footballers);
        }
        public IActionResult Edit(int id)
        {
            ViewData["Teams"] = dataManager.Teams.GetAll();
            return View(dataManager.Footballers.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Footballer footballer,string teamName)
        {
            var team = dataManager.Teams.Get(e => e.Name.Equals(teamName)).FirstOrDefault();
            int teamId;
            if (team is null)
                teamId = dataManager.Teams.Add(new Team() { Name = teamName });
            else teamId = team.Id;
            footballer.TeamId = teamId;
            dataManager.Footballers.Update(footballer);
            signalHub.Clients.All.SendAsync("LoadProducts");
            return RedirectToAction("FootballersList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            dataManager.Footballers.Remove(id);
            signalHub.Clients.All.SendAsync("LoadProducts");
            return RedirectToAction("FootballersList");
        }
    }
}
