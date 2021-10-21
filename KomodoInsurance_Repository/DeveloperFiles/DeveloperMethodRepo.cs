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

        public void UpdateDeveloperInfo(int devID)
        {
            //Takes in a developerID and updates any of it's information
            foreach (Developer dev in _devDirectory)
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
                            ChangeFirstAndLastName(dev);
                            break;
                        case "2":
                            ChangeLastName(dev);
                            break;
                        case "3":
                            ChangeFirstName(dev);
                            break;
                        case "4":
                            ChangeRole(dev);
                            break;
                        case "5":
                            ChangeGender(dev);
                            break;
                        case "6":
                            ChangeAge(dev);
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

        }

        public List<Developer> GetAllDevelopers()
        {
            return _devDirectory;
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
        public bool RemoveDeveloper(int devID)
        {
            //Removes a developer from the company -- will automaticallty remove them from any team they are in
            Developer devToRemove = GetDeveloperByID(devID);
            
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
    }
}
