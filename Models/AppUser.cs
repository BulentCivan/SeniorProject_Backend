using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser : IdentityUser
    {
        public string? UserSurname { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string MarialStatus { get; set; }

        public string EducationField { get; set; }
        public string EducationLevel { get; set; }
        public string LongestResidence { get; set; }

        public string MonthlyIncome { get; set; }

        public bool ChronicCondition { get; set; }
        public string ChronicConditionName { get; set; }

        public string ChronicConditionMed { get; set; }
        public bool PsychologicalCondition { get; set; }

        public string PsychologicalConditionMed { get; set; }

        public string ReceivingPsychoTreatment { get; set; }

        public int ProgressLevel { get; set; }
        public int AdminId { get; set; }

        public List<UserParadigm> UserParadigms { get; set; } = new List<UserParadigm>();
        public List<UserMood> UserMoods { get; set; } = new List<UserMood>();

    }
}