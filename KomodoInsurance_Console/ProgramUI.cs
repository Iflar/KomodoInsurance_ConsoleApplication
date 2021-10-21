using KomodoInsurance_Repository;
using KomodoInsurance_Repository.DeveloperFiles;
using KomodoInsurance_Repository.DeveloperTeamFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    class ProgramUI
    {
        private readonly DevTeamMethodRepo _teamRepo = new DevTeamMethodRepo();
        private readonly DeveloperMethodRepo _devRepo = new DeveloperMethodRepo();

        public void Run()
        {
            bool ContinueToRun = true;
            while (ContinueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome administrator, what wouldd you like to do today?");
                Console.WriteLine("Here is a list of options:\n" +
                    "1. Hire new Developer\n" +
                    "2. Create new DevTeam\n" +
                    "3. Add developer to team\n" +
                    "4. Remove developer from team\n" +
                    "5. Delete DevTeam\n" +
                    "6. Update DeveTeam's roles\n" +
                    "7. Update developer information\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        CreateDevTeam();
                        break;
                    case "3":
                        AddDeveloperToTeam();
                        break;
                    case "4":
                        RemoveDeveloperFromTeam();
                        break;
                    case "5":
                        
                        break;
                    case "6":

                        break;
                    case "7":

                        break;
                    default:
                        Console.WriteLine("Enter 1-3 for your selection");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                }

            }

        }
        public int CreateDeveloper()
        {
            Developer developer = new Developer();
            Console.WriteLine("You've hired a new developer, please fill out the neccisary information.");
            Console.ReadKey();
            bool runGenderLoop = true;
            while (runGenderLoop == true)
            {
                Console.Clear();
                Console.WriteLine("Select gender:\n" +
                    "1. Male\n" +
                    "2. Female\n" +
                    "3. Unspecified");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        developer.Gender = Gender.Male;
                        runGenderLoop = false;
                        break;
                    case "2":
                        developer.Gender = Gender.Female;
                        runGenderLoop = false;
                        break;
                    case "3":
                        developer.Gender = Gender.Unspecified;
                        runGenderLoop = false;
                        break;
                    default:
                        Console.WriteLine("Enter 1-3 for your selection");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

            string pronoun = "their";
            if (developer.Gender == Gender.Male)
            {
                pronoun = "his";
            }
            else if (developer.Gender == Gender.Female)
            {
                pronoun = "her";
            }
            else if (developer.Gender == Gender.Unspecified)
            {
                pronoun = "their";
            }

            Console.WriteLine($"Enter {pronoun} first name:");
            string devFirstName = Console.ReadLine();
            developer.FirstName = devFirstName;
            Console.Clear();

            Console.WriteLine($"Enter {pronoun} last name:");
            string devLastName = Console.ReadLine();
            developer.LastName = devLastName;
            Console.Clear();

            Console.WriteLine($"Enter {pronoun} age");
            bool runAgeLoop = true;
            while (runAgeLoop == true)
            {
                try
                {
                    int age = int.Parse(Console.ReadLine());
                    developer.Age = age;
                    Console.Clear();
                    runAgeLoop = false;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid whole number");
                }

            }


            Console.WriteLine($"What is {pronoun} developer ID?");
            bool runIDLoop = true;
            while (runIDLoop == true)
            {
                try
                {

                    bool runNumCheckLoop = true;
                    while (runNumCheckLoop == true)
                    {
                        int devID = int.Parse(Console.ReadLine());
                        if (devID > 0)
                        {
                            developer.DeveloperID = devID;
                            Console.Clear();
                            runNumCheckLoop = false;
                            runIDLoop = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a number greater than 0");
                            Console.WriteLine("Press enter to try again");
                            Console.ReadKey();
                            Console.WriteLine($"What is {pronoun} developer ID?");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid intager");
                }
            }
            bool runRoleLoop = true;
            while (runRoleLoop == true)
            {
                Console.Clear();
                Console.WriteLine("Select Dev Role:\n" +
                    "1. QA\n" +
                    "2. FrontEnd\n" +
                    "3. BackEnd\n" +
                    "4. UX Designer");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        developer.DevRole = Role.QA;
                        runRoleLoop = false;
                        break;
                    case "2":
                        developer.DevRole = Role.FrontEnd;
                        runRoleLoop = false;
                        break;
                    case "3":
                        developer.DevRole = Role.BackEnd;
                        runRoleLoop = false;
                        break;
                    case "4":
                        developer.DevRole = Role.UX;
                        runRoleLoop = false;
                        break;
                    default:
                        Console.WriteLine("Enter 1-4 for your selection");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
            //call add dev to repo here
            return developer.DeveloperID;
        }
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
                    _teamRepo.AddTeamToDirectory(newTeam);
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
        public void RemoveDeveloperFromTeam()
        {
            Console.WriteLine("What team do you want to remove the developer from?");
            List<DevTeam> teamList = _teamRepo.GetAllTeams();
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
                foreach(KeyValuePair<int, Developer> developer in SelectedTeam.DevDictionary)
                {
                    Console.WriteLine("now we're getting somewhere...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No content has that ID");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();

        }
        public void AddDeveloperToTeam()
        {
            Console.WriteLine("Waht team would you like add the developer to?");
            List<DevTeam> teamList = _teamRepo.GetAllTeams();
            int count = 0;
            foreach (DevTeam team in teamList)
            {
                count++;
                Console.WriteLine($"{count}. {team.TeamName}");
            }


            List<Developer> developerList = _devRepo.GetAllDevelopers();
            int devCount = 0;
            foreach (Developer developer in developerList)
            {
                devCount++;
                Console.WriteLine($"{devCount}. {developer.FirstName} {developer.LastName}");
            }
        }
        public void DeleteTeam()
        {
            Console.WriteLine("What team would you like to remove?");
            List<DevTeam> teamList = _teamRepo.GetAllTeams();
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
                if (_teamRepo.RemoveTeam(SelectedTeam))
                {
                    Console.WriteLine($"{SelectedTeam.TeamName} has been deleted.");
                }
                else
                {
                    Console.WriteLine("That's rather strange... You might want to sit down for this one.....");
                }
            }
            else
            {
                Console.WriteLine("No content has that ID");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();

        }
        public bool AddDeveloperToTeam(int devID, string teamName)
        {
            Developer developer = _devRepo.GetDeveloperByID(devID);
            DevTeam teamToBeAdded = _teamRepo.GetTeamByName(teamName);

            int startCount = teamToBeAdded.DevDictionary.Count;

            teamToBeAdded.DevDictionary.Add(developer.DeveloperID, developer);

            bool wasAdded = teamToBeAdded.DevDictionary.Count > startCount ? true : false;
            return wasAdded;
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
        
        public void ChangeFirstAndLastName(Developer developer)
        {
            Console.WriteLine($"What is their new first name?");
            string devFirstName = Console.ReadLine();
            developer.FirstName = devFirstName;
            Console.Clear();

            Console.WriteLine($"What is their new last name?");
            string devLastName = Console.ReadLine();
            developer.LastName = devLastName;
            Console.Clear();

        }
        public void ChangeLastName(Developer developer)
        {
            Console.WriteLine($"What is their new last name?");
            string devLastName = Console.ReadLine();
            developer.LastName = devLastName;
            Console.Clear();
        }
        public void ChangeFirstName(Developer developer)
        {
            Console.WriteLine($"What is their new first name?");
            string devFirstName = Console.ReadLine();
            developer.FirstName = devFirstName;
            Console.Clear();
        }
        public void ChangeRole(Developer developer)
        {
            bool runRoleLoop = true;
            while (runRoleLoop == true)
            {
                Console.Clear();
                Console.WriteLine("Select new Dev Role:\n" +
                    "1. QA\n" +
                    "2. FrontEnd\n" +
                    "3. BackEnd\n" +
                    "4. UX Designer");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        developer.DevRole = Role.QA;
                        runRoleLoop = false;
                        break;
                    case "2":
                        developer.DevRole = Role.FrontEnd;
                        runRoleLoop = false;
                        break;
                    case "3":
                        developer.DevRole = Role.BackEnd;
                        runRoleLoop = false;
                        break;
                    case "4":
                        developer.DevRole = Role.UX;
                        runRoleLoop = false;
                        break;
                    default:
                        Console.WriteLine("Enter 1-4 for your selection");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ChangeGender(Developer developer)
        {
            bool runGenderLoop = true;
            while (runGenderLoop == true)
            {
                Console.Clear();
                Console.WriteLine("Select new gender:\n" +
                    "1. Male\n" +
                    "2. Female\n" +
                    "3. Unspecified");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        developer.Gender = Gender.Male;
                        runGenderLoop = false;
                        break;
                    case "2":
                        developer.Gender = Gender.Female;
                        runGenderLoop = false;
                        break;
                    case "3":
                        developer.Gender = Gender.Unspecified;
                        runGenderLoop = false;
                        break;
                    default:
                        Console.WriteLine("Enter 1-3 for your selection");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

        }
        public void ChangeAge(Developer developer)
        {
            bool runAgeLoop = true;
            while (runAgeLoop == true)
            {
                try
                {
                    Console.WriteLine("Enter new age");
                    int age = int.Parse(Console.ReadLine());
                    developer.Age = age;
                    Console.Clear();
                    runAgeLoop = false;
                }
                catch
                {
                    Console.WriteLine("Please enter a valid whole number");
                }

            }
        }
    }

}
