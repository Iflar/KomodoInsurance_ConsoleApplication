using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository.DeveloperTeamFiles
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public Developer TeamLead { get; set; }
        public Dictionary<int, Developer> DevDictionary { get; set; }
        public int NumDevelopersInTeam
        {
            get
            {
                return DevDictionary.Count();
            }
        }

        /*Basic constructor*/
        public DevTeam()
        {
            DevDictionary = new Dictionary<int, Developer>();
        }

        /*Overloaded constructor*/
        public DevTeam(string teamName, Developer teamLead)
        {
            TeamName = teamName;
            TeamLead = teamLead;

            DevDictionary = new Dictionary<int, Developer>();
        }
    }
}
