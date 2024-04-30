using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account
{
    public class RegisterDto
    {
        public string? UserName {get; set;} 
        public string? UserSurname {get; set;} 
        public int? Age {get; set;}

        public string? Password {get; set;}
        [EmailAddress]
        public string? Email {get; set;} 
        public string Gender { get;  set; }

        public string IsMarried { get;  set; }
        
        public string Department { get;  set; }
        public string Class { get;  set; }
        public string Accomodation { get;  set; }
        public bool HasUnease { get;  set; } //Physical illnes

        public bool HasUneaseMedicine { get;  set; }
        public bool HasPsychologicalDisorder { get;  set; } //Psychological illnes 	psychological treatment

        public bool HasPsychologicalDisorderMedicine { get;  set; }
        public bool HasPsychologicalTreatment { get;  set; }
        public int Income { get;  set; }
        
      
    }
}