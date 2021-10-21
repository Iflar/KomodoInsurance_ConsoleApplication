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
        public void Run()
        {
            DevTeamMethodRepo _teamRepo = new DevTeamMethodRepo();
            DeveloperMethodRepo _devRepo = new DeveloperMethodRepo();

            _devRepo.CreateDeveloper();

            

            
        }
    }
}
