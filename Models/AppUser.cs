using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {public string? UserName {get; set;} 
        public string? UserSurname {get; set;} 
        public int? Age {get; set;}

        public string? Password {get; set;}
        [EmailAddress]
        public string? Email {get; set;} 
       public string CellPhone { get;  set; }
        public string Gender { get;  set; }
        public string MarialStatus { get;  set; }
        
        public string EducationField { get;  set; }
        public string EducationLevel { get;  set; }
        public string LongestResidence { get;  set; }
       
       public int MonthlyIncome { get;  set; }
       
        public bool ChronicCondition { get;  set; } 
        public string ChronicConditionName { get;  set; }

       public string ChronicConditionMed { get;  set; }
        
        public bool PsychologicalCondition { get;  set; } 

        public string PsychologicalConditionMed { get;  set; } 

        public string ReceivingPsychoTreatment { get;  set; } 

        public int ProgressLevel { get;  set; } 



    }
}