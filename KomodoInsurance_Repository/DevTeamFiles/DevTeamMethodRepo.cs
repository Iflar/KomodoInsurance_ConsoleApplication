using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository.DeveloperTeamFiles
{

    public class DevTeamMethodRepo
    {

        Developer developer1;

        public void AddDeveloperToTeam(Developer developer)
        {
            //This method will add a developer into the team
            
        }
        public void RemoveDeveloperFromTeam(Developer developer)
        {
            //Removes a developer from the team by ID
        }
        public void UpdateDeveloperRolesInTeam()
        {
            // Takes in a developer object and changes the role of that developer on the team
        }
        public void ReadDeveloperByID()
        {
            //locates a developer by their ID
        }

        public DevTeamMethodRepo()
        {
            DevTeam _team1 = new DevTeam();
            developer1 = new Developer(1, "John", "Smith", 26, Gender.Male, Role.FrontEnd, DateTime.Now, _team1);
        }

    }


}
