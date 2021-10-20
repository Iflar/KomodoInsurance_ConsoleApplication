using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Console
{
    class Program
    {
        /*
        Notes:

            Directive:
        Create a program that manages a companies software development department.

        Basic Project Reqs: 
            - Two repos with their own CRUD methods
            - Two classes with thier own props
            - User input

            Break it down:
        Department consists of developers and dev teams - each team has a team lead.

            | Developer
                - the developer class will require team lead prop - this can be a bool or it's own class that is a child of the dev class.

                - basic qualities that make up a person -- first and last name, age, gender, years of exp.

                - Role on the team (excluding lead position... mabey) - this will be an enum - QA, UX, Front end, Back end

                - due to the fact that our Developer objects require a dev team in order to be creaated - we will have
                    a 'DevTeam' called "Unassigned" this will be the default team all developers are put in whne created.
        ------------------------------------------------------------------------------------------------------------------------------------------------
            | Dev Team
                - will havea Dictionary prop that contains the developers

                - number of developers -- this prop (int) will be get only -- referance the dictionary prop

                - Team name

                - Team project -- potentally created by the product manager (the user of this application)

         -- Some ideas to spice it up:
            - If you have at least 20years of experiance, you are eligable for the team lead position.
                --
            - Your promotion depends that^ fact, and the number of projects completed on your team. 
                --
            - In addition, a manager may premote or demote any developer at any time they see fit.
                --
            - Team lead can reccomend someone for premotion.
        */
        static void Main(string[] args)
        {
            ProgramUI UI = new ProgramUI();
            UI.Run();
        }
    }
}
