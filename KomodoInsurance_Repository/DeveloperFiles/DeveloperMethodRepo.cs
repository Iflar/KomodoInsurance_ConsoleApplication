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
    }
}
