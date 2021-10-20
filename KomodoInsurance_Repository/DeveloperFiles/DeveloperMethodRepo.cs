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
                    int devID = int.Parse(Console.ReadLine());
                    developer.DeveloperID = devID;
                    Console.Clear();
                    runIDLoop = false;
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
            return developer.DeveloperID;
        }

        public void UpdateDeveloperInfo(Developer developer)
        {
            //Takes in a developerID and updates any of it's information

        }
        /*Helper method for UpdateDeveloperInfo*/
        public int AcquireDeveloperByID()
        {
            return 0;
        }

        public void RemoveDeveloper()
        {
            //Removes a developer from the company -- will automaticallty remove them from any team they are in
        }
        public void ReadDeveloperInfo()
        {
            //Takes in a developerID and displays all the information related to that developer
        }
    }
}
