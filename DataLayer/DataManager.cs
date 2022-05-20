
namespace DataLayer
{
    public class DataManager
    {
        public IRepository<Footballer> Footballers { get; private set; }
        public IRepository<Team> Teams { get; private set; }

        public DataManager(IRepository<Footballer> footballers, IRepository<Team> teams)
        {
            Footballers = footballers;
            Teams = teams;
        }
    }
}
