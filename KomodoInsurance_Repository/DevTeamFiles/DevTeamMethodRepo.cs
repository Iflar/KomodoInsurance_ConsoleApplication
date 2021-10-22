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
        public bool UpdateDeveloperRole(Developer devToUpdate)
        {
            // Takes in a developer object and changes the role of that developer on the 
            bool runRoleLoop = true;
            while (runRoleLoop == true)
            {
                Console.Clear();
                Console.WriteLine("Select New Dev Role:\n" +
                    "1. QA\n" +
                    "2. FrontEnd\n" +
                    "3. BackEnd\n" +
                    "4. UX Designer");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        devToUpdate.DevRole = Role.QA;
                        return true;
                    case "2":
                        devToUpdate.DevRole = Role.FrontEnd;
                        return true;
                    case "3":
                        devToUpdate.DevRole = Role.BackEnd;
                        return true;
                    case "4":
                        devToUpdate.DevRole = Role.UX;
                        return true;
                    default:
                        Console.WriteLine("Enter 1-4 for your selection");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
            return false;
        }
        public DevTeam SelectDevTeam()
        {
            List<DevTeam> teamList = GetAllTeams();
            int teamCheck = teamList.Count();
            if (teamCheck > 0)
            {
                Console.WriteLine("What team would you like add the developers to?");
                int count = 0;
                foreach (DevTeam team in teamList)
                {
                    count++;
                    Console.WriteLine($"{count}. {team.TeamName}");
                }

                int TargetTeam = int.Parse(Console.ReadLine());
                int targetIndex = TargetTeam - 1;
                if (targetIndex >= 0 && targetIndex < teamList.Count)
                {
                    DevTeam SelectedTeam = teamList[targetIndex];

                    return SelectedTeam;
                }
                else
                {
                    Console.WriteLine("It seems we need to create a developer team first.");
                    Console.ReadKey();
                    
                }
            }
            return null;
        }
    }
}
