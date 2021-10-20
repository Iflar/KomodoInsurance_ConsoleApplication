using KomodoInsurance_Repository.DeveloperTeamFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public enum Gender { Male, Female, Unspecified }
    public enum Role { QA, UX, FrontEnd, BackEnd }
    public class Developer
    {
        public int DeveloperID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Role DevRole { get; set; }

        /*basic constructor*/
        public Developer() { }

        /*Overloaded constructor*/
        public Developer(int developerID, string firstName, string lastName, int age, Gender gender, Role devRole, bool isTeamLead)
        {
            DeveloperID = developerID;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            DevRole = devRole;
        }

        public int GetDevTeamDictionaryCount(DevTeam devTeam)
        {
            int devDictInitVal = devTeam.DevDictionary.Count();
            return devDictInitVal++;
        }

    }
}
