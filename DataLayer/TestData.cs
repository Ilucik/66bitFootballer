using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class TestData
    {
        public static void InitData(DataManager dataManager)
        {
            if (!dataManager.Teams.GetAll().Any())
            {
                dataManager.Teams.Add(new Team() { Name = "Команда1" });
                dataManager.Teams.Add(new Team() { Name = "Команда2" });
            }
            if (!dataManager.Footballers.GetAll().Any())
            {
                dataManager.Footballers.Add(new Footballer() { Name = "Имя1", Surname = "Фамилия1", Country = "Россия", Gender = 'm', Birthday = DateTime.Now, TeamId = 1 });
                dataManager.Footballers.Add(new Footballer() { Name = "Имя2", Surname = "Фамилия2", Country = "Россия", Gender = 'm', Birthday = DateTime.Now, TeamId = 1 });
                dataManager.Footballers.Add(new Footballer() { Name = "Имя3", Surname = "Фамилия3", Country = "США", Gender = 'f', Birthday = DateTime.Now, TeamId = 2 });
            }
        }
    }
}
