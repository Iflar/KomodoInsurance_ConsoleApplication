using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository.DeveloperTeamFiles
{
    public class DevTeamMethodRepo
    {
        //this list is used to contain devteams and allow searching trough devteam props in other methods.
        private readonly List<DevTeam> _teamDirectory = new List<DevTeam>();
        public string CreateDevTeam()
        {
            DevTeam newTeam = new DevTeam();

            bool stupidUser = true;
            while (stupidUser == true)
            {
                Console.WriteLine("Give your new team a name.");
                string input = Console.In.ReadLine();
                int inputLength = input.Length;

                if (inputLength > 0 && inputLength < 12)
                {
                    stupidUser = false;
                    newTeam.TeamName = input;
                    Console.WriteLine($"Okay, the team name is: {newTeam.TeamName}");
                    Console.ReadKey();
                    _teamDirectory.Add(newTeam);
                    return newTeam.TeamName;
                }
                else if (inputLength > 12)
                {
                    Console.WriteLine("Too many characters, please try again.");
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
            return null;
        }

        public bool AddDeveloperToTeam(Developer developer, string teamName)
        {
           DevTeam teamToBeAdded GetTeamByName(teamName)
            int startCount = teamToBeAdded.DevDictionary.Count;

            teamToBeAdded.DevDictionary.Add(developer.DeveloperID, developer);

            bool wasAdded = teamToBeAdded.DevDictionary.Count > startCount ? true : false;
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

        public bool RemoveDeveloperFromTeamByID(DevTeam devTeam, int devID)
        {
            //Removes a developer from the team by ID
            foreach (KeyValuePair<int, Developer> kvp in devTeam.DevDictionary)
            {
                Developer developer = kvp.Value;
                if (developer.DeveloperID == devID)
                {
                    devTeam.DevDictionary.Remove(devID);
                    Console.WriteLine($"{developer.FirstName} {developer.LastName} was removed from the team");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return default;
        }

        public bool UpdateDeveloperRoleInTeam(DevTeam team, int devID, Role newRole)
        {
            // Takes in a developer object and changes the role of that developer on the team
            foreach (KeyValuePair<int, Developer> kvp in team.DevDictionary)
            {
                Developer developer = kvp.Value;
                if (developer.DeveloperID == devID)
                {
                    developer.DevRole = newRole;
                    Console.WriteLine($"{developer.FirstName} {developer.LastName}'s new role is: {developer.DevRole}");
                    Console.ReadKey();
                    return true;
                }

            }
            return false;
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

        public DevTeamMethodRepo()
        {
            DevTeam _team1 = new DevTeam();
        }

    }


}
