using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Paradigms")]
    public class Paradigm
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Result { get; set; }
        public string PatientEmail { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<UserParadigm> UserParadigms{ get; set; } = new List<UserParadigm>();

    }
}