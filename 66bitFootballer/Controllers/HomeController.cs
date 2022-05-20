using _66bitFootballer.Models;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Linq;

namespace _66bitFootballer.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IHubContext<SignalServer> signalHub;

        public HomeController(DataManager dataManager, IHubContext<SignalServer> signalHub)
        {
            this.dataManager = dataManager;
            this.signalHub = signalHub;
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
            signalHub.Clients.All.SendAsync("LoadProducts");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
