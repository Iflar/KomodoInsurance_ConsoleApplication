using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository.DeveloperTeamFiles
{

    public class DevTeamMethodRepo
    {
        public bool CreateDevTeam()
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
                    return true;
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
            return false;
        }

        public bool AddDeveloperToTeam(Developer developer, DevTeam teamToBeAdded)
        {
            int startCount = teamToBeAdded.DevDictionary.Count;

            teamToBeAdded.DevDictionary.Add(developer.DeveloperID, developer);

            bool wasAdded = teamToBeAdded.DevDictionary.Count > startCount ? true : false;
            return wasAdded;
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
        public void UpdateDeveloperRolesInTeam()
        {
            // Takes in a developer object and changes the role of that developer on the team
        }
        public void ReadDeveloperByID(int devID)
        {
            //locates a developer by their ID
        }

        public DevTeamMethodRepo()
        {
            DevTeam _team1 = new DevTeam();
        }

    }


}
