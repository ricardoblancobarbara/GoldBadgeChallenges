using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Badge_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> ListOfDoors { get; set; } = new List<string>();
        public string Name { get; set; }

        public Badge() { }

        public Badge(int badgeId, List<string> listOfDoors, string name)  
        {
            BadgeID = badgeId;
            ListOfDoors = listOfDoors;
            Name = name;
        }
    }
}
