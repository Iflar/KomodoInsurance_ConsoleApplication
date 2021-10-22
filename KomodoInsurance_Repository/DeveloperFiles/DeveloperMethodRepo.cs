using KomodoInsurance_Repository.DeveloperTeamFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository.DeveloperFiles
{
    public class DeveloperMethodRepo
    {
        //this list is used to contain Developers to then be accesed in other methods.
        protected readonly List<Developer> _devDirectory = new List<Developer>();
        public List<Developer> GetAllDevelopers()
        {
            return _devDirectory;
        }
        public bool AddDevToDirectory(Developer developer)
        {
            int startingCount = _devDirectory.Count;
            _devDirectory.Add(developer);
            bool wasAdded = _devDirectory.Count > startingCount ? true : false;
            return wasAdded;
        }
        /*Helper method for UpdateDeveloperInfo*/
        public Developer GetDeveloperByID(int devID)
        {
            foreach (Developer dev in _devDirectory)
            {
                if (devID == dev.DeveloperID)
                {
                    return dev;
                }
                else
                {
                    Console.WriteLine("No developer with that ID existis whithin out database.");
                    Console.ReadKey();
                    return null;
                }
            }
            return null;
        }
        public int GetDevID(int devID)
        {
            foreach (Developer dev in _devDirectory)
            {
                if (devID == dev.DeveloperID)
                {
                    return dev.DeveloperID;
                }
                else
                {
                    Console.WriteLine("No developer with that ID existis whithin out database.");
                    Console.ReadKey();
                    return 0;
                }
            }
            return 0;
        }
        public bool RemoveDeveloper(Developer devToRemove)
        {
            int startCount = _devDirectory.Count;

            _devDirectory.Remove(devToRemove);

            bool wasRemoved = _devDirectory.Count < startCount ? true : false;
            return wasRemoved;
        }
        public void ReadDeveloperInfo(int devID)
        {
            //Takes in a developerID and displays all the information related to that developer
            Developer devToRead = GetDeveloperByID(devID);
            Console.WriteLine($"Developer ID is {devToRead.DeveloperID}");
            Console.WriteLine($"Developer name is{devToRead.FirstName} {devToRead.LastName}");
            Console.WriteLine($"Developer gender is {devToRead.Gender}");
            Console.WriteLine($"Developer Role is {devToRead.DevRole}");
        }

        public Developer SelectDevelopers()
        {

            List<Developer> developerList = GetAllDevelopers();
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
                int targetDevIndex = TargetDev;
                if (targetDevIndex >= 0 && targetDevIndex < developerList.Count)
                {
                    Developer SelectedDeveloper = developerList[targetDevIndex];
                    return SelectedDeveloper;
                }
            }
            Console.WriteLine("There are no developers!");
            return null;
        }

        //Update Methods:

        public void ChangeLastName(Developer developer)
        {
            string devLastName = Console.ReadLine();
            developer.LastName = devLastName;
            Console.Clear();
        }
        public void ChangeFirstName(Developer developer)
        {
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
