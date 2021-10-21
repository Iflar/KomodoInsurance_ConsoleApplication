using KomodoInsurance_Repository.DeveloperFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository.DeveloperTeamFiles
{
    public class DevTeamMethodRepo
    {


        //this list is used to contain devteams to then be accesed in other methods.
        protected readonly List<DevTeam> _teamDirectory = new List<DevTeam>();
        
        public bool AddTeamToDirectory(DevTeam team)
        {
            int startingCount = _teamDirectory.Count;
            _teamDirectory.Add(team);
            bool wasAdded = _teamDirectory.Count > startingCount ? true : false;
            return wasAdded;
        }
        public DevTeam GetTeamByName(string teamName)
        {
            foreach (DevTeam team in _teamDirectory)
            {
                if (teamName == team.TeamName)
                {
                    return team;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public List<DevTeam> GetAllTeams()
        {
            return _teamDirectory;
        }
        public bool RemoveTeam(DevTeam team)
        {
            bool deleteResult = _teamDirectory.Remove(team);
            return deleteResult;

        }
        public void ReadDeveloperByID(DevTeam team, int devID)
        {
            //locates a developer by their ID
            foreach (KeyValuePair<int, Developer> kvp in team.DevDictionary)
            {
                Developer developer = kvp.Value;
                if (developer.DeveloperID == devID)
                {
                    Console.WriteLine($"Here is all the info we have on {developer.FirstName} {developer.LastName}:\n" +
                        $"DevID:    {developer.DeveloperID}\n" +
                        $"-----\n" +
                        $"Role:     {developer.DevRole}\n" +
                        $"-----" +
                        $"Age:      {developer.Age}\n" +
                        $"-----\n" +
                        $"Gender:   {developer.Gender}\n" +
                        $"-----");
                    Console.ReadKey();
                }

            }

        }
    }


}
