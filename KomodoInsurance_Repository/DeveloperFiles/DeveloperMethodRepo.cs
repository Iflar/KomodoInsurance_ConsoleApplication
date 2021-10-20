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

        public bool CreateDeveloper(DevTeam team) /*A DevTeam object is requiered to make a new Developer - I'd like to change this. */
        {
            if (team != null)
            {
                Developer developer = new Developer();
                return true;
            }
            return false;
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
