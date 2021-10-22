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
        protected readonly DevTeamMethodRepo _teamRepo = new DevTeamMethodRepo();
        protected readonly DeveloperMethodRepo _devRepo = new DeveloperMethodRepo();

        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
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
                    "7. Update developer information\n" +
                    "8. Add multiple devs to team");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        CreateDeveloper();
                        break;
                    case "2":
                        Console.Clear();
                        CreateDevTeam();
                        break;
                    case "3":
                        Console.Clear();
                        AddDeveloperToTeam();
                        break;
                    case "4":
                        Console.Clear();
                        RemoveDeveloperFromTeam();
                        break;
                    case "5":
                        Console.Clear();
                        DeleteDevTeam();
                        break;
                    case "6":

                        break;
                    case "7":
                        Console.Clear();
                        UpdateDeveloperInfo();
                        break;
                    case "8":
                        Console.Clear();
                        AddMultipleDevsToTeam();
                        break;
                    default:
                        Console.WriteLine("Enter 1-7 for your selection");
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
            Console.Clear();
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
                        Console.Clear();
                        developer.Gender = Gender.Male;
                        runGenderLoop = false;
                        break;
                    case "2":
                        Console.Clear();
                        developer.Gender = Gender.Female;
                        runGenderLoop = false;
                        break;
                    case "3":
                        Console.Clear();
                        developer.Gender = Gender.Unspecified;
                        runGenderLoop = false;
                        break;
                    default:
                        Console.Clear();
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
            _devRepo.AddDevToDirectory(developer);
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
            List<DevTeam> teamList = _teamRepo.GetAllTeams();
            int teamCheck = teamList.Count();

            if (teamCheck > 0)
            {
                Console.WriteLine("What team would you like remove the developer from?");
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


                    Dictionary<int, Developer> developerList = SelectedTeam.DevDictionary;
                    int devCheck = developerList.Count();

                    if (devCheck > 0)
                    {
                        Console.WriteLine("Which developer would you like to remove?");
                        int dCount = 0;
                        List<Developer> devIndex = new List<Developer>();
                        foreach (KeyValuePair<int, Developer> kvp in developerList)
                        {
                            Developer developer = kvp.Value;
                            dCount++;
                            Console.WriteLine($"{dCount}. {developer.FirstName} {developer.LastName} ID#: {developer.DeveloperID}");
                            devIndex.Add(developer);
                        }

                        int TargetDev = int.Parse(Console.ReadLine());
                        int targetDevIndex = TargetDev - 1;
                        if (targetDevIndex >= 0 && targetDevIndex < developerList.Count)
                        {
                            Developer SelectedDeveloper = devIndex[targetDevIndex];

                            SelectedTeam.DevDictionary.Remove(SelectedDeveloper.DeveloperID);
                            Console.WriteLine("Developer removed");
                            Console.ReadKey();
                        }
                    }
                }
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("It seems we need to create a developer team first.");
                Console.ReadKey();
            }
        }
        public void AddDeveloperToTeam()
        {
            List<DevTeam> teamList = _teamRepo.GetAllTeams();
            int teamCheck = teamList.Count();

            if (teamCheck > 0)
            {
                Console.WriteLine("What team would you like add the developer to?");
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


                    List<Developer> developerList = _devRepo.GetAllDevelopers();
                    int devCheck = developerList.Count();

                    if (devCheck > 0)
                    {
                        Console.WriteLine("Whitch developer would you like to add?");
                        int dCount = 0;
                        foreach (Developer developer in developerList)
                        {
                            dCount++;
                            Console.WriteLine($"{dCount}. {developer.FirstName} {developer.LastName} ID#: {developer.DeveloperID}");
                        }

                        int TargetDev = int.Parse(Console.ReadLine());
                        int targetDevIndex = TargetDev - 1;
                        if (targetDevIndex >= 0 && targetDevIndex < developerList.Count)
                        {
                            Developer SelectedDeveloper = developerList[targetDevIndex];

                            SelectedTeam.DevDictionary.Add(SelectedDeveloper.DeveloperID, SelectedDeveloper);

                            Console.WriteLine("Developer Added");

                            Console.ReadKey();
                        }
                    }
                }
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("It seems we need to create a developer team first.");
                Console.ReadKey();
            }
        }
        public void AddMultipleDevsToTeam()
        {
           
            bool shouldRun = true;
            while (shouldRun == true)
            {
                Console.WriteLine("You may add up to 4 developers to a team at once.");
                Console.WriteLine("How many would you like to add?");
                try
                {
                    int numToAdd = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (numToAdd < 5 && numToAdd > 0)
                    {
                        List<DevTeam> teamCheckList = _teamRepo.GetAllTeams();
                        int teamCheck = teamCheckList.Count();
                        List<Developer> devCheckList = _devRepo.GetAllDevelopers();
                        int devCheck = devCheckList.Count();
                        if (numToAdd >= devCheck)
                        {
                            DevTeam teamToAdd = _teamRepo.SelectDevTeam();
                            shouldRun = false;
                            while (numToAdd > 0)
                            {
                                _devRepo.SelectDevelopers(teamToAdd);
                                --numToAdd;
                            }
                        }
                        else
                        {
                            Console.WriteLine("We don't have enough developers!");
                        }
                        
                    }
                    else if (numToAdd <= 0)
                    {
                        Console.WriteLine("please use a real number.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("You cannot add more than 4 developers at a time.\n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.ReadKey();
                }
            }
        }
        public void DeleteDevTeam()
        {
            List<DevTeam> teamList = _teamRepo.GetAllTeams();
            int teamCheck = teamList.Count();

            if (teamCheck > 0)
            {
                Console.WriteLine("What team would you like to delete?");
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
                    teamList.Remove(SelectedTeam);
                    Console.WriteLine("Team deleted");
                }
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There are no dev teams to delete...");
                Console.ReadKey();
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
        public void UpdateDeveloperInfo()
        {
            //Takes in a developerID and updates any of it's information
            List<Developer> devList = _devRepo.GetAllDevelopers();
            Console.WriteLine("Please insert developer ID");
            bool runIDLoop = true;
            while (runIDLoop == true)
            {
                try
                {
                    bool runNumCheckLoop = true;
                    while (runNumCheckLoop == true)
                    {
                        int devID = int.Parse(Console.ReadLine());
                        foreach (Developer dev in devList)
                        {
                            if (devID == dev.DeveloperID)
                            {
                                Console.WriteLine($"What would you like to update for {dev.FirstName} {dev.LastName}?");
                                Console.WriteLine("choose from the following:\n" +
                                    "1. Name - first and last\n" +
                                    "2. Last name\n" +
                                    "3. First name\n" +
                                    "4. Role\n" +
                                    "5. Gender\n" +
                                    "6. Age");
                                string input = Console.ReadLine();
                                switch (input)
                                {
                                    case "1":
                                        Console.Clear();
                                        Console.WriteLine($"What is their new first name?");
                                        _devRepo.ChangeFirstName(dev);
                                        Console.Clear();
                                        Console.WriteLine($"What is their new last name?");
                                        _devRepo.ChangeLastName(dev);
                                        break;
                                    case "2":
                                        Console.Clear();
                                        Console.WriteLine($"What is their new last name?");
                                        _devRepo.ChangeLastName(dev);
                                        break;
                                    case "3":
                                        Console.Clear();
                                        Console.WriteLine($"What is their new first name?");
                                        _devRepo.ChangeFirstName(dev);
                                        break;
                                    case "4":
                                        Console.Clear();
                                        _devRepo.ChangeRole(dev);
                                        break;
                                    case "5":
                                        Console.Clear();
                                        _devRepo.ChangeGender(dev);
                                        break;
                                    case "6":
                                        Console.Clear();
                                        _devRepo.ChangeAge(dev);
                                        break;
                                    default:
                                        Console.WriteLine("Enter 1-4 for your selection");
                                        Console.WriteLine("Press any key to continue.");
                                        Console.ReadKey();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("No developer with that ID existis whithin out database.");
                                Console.ReadKey();
                            }
                        }
                        if (devID > 0)
                        {

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
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid intager");
                }
            }
        }
    }
}
