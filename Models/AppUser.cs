using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public string UserSurname { get;  set; }
        public int Age { get;  set; }
        public string Gender { get;  set; }

        public string IsMarried { get;  set; }
        
        public string Department { get;  set; }
        public string Class { get;  set; }
        public string Accomodation { get;  set; }
        public bool HasUnease { get;  set; } //Physical illnes

        public bool HasUneaseMedicine { get;  set; }
        public bool HasPsychologicalDisorder { get;  set; } //Psychological illnes

        public bool HasPsychologicalDisorderMedicine { get;  set; }
        public bool HasPsychologicalTreatment { get;  set; }
        public int Income { get;  set; }


    }
}