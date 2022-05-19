using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Footballer : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public char Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int TeamId { get; set; }
        public string Country { get; set; }
    }
}
