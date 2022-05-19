using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _66bitFootballer
{
    public class FootballersListController : Controller
    {
        private readonly DataManager dataManager;
        public FootballersListController(DataManager dataManager)
        {
            this.dataManager = dataManager;
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
        public IActionResult Edit(Footballer footballer)
        {
            dataManager.Footballers.Update(footballer);
            return RedirectToAction("FootballersList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            dataManager.Footballers.Remove(id);
            return RedirectToAction("FootballersList");
        }
    }
}
