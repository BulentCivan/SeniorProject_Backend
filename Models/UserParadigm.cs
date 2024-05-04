using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("UserParadigms")]
    public class UserParadigm
    {
        public string AppUserId { get; set; }
        public int ParadigmId { get; set;}
        public AppUser AppUser { get; set; }
        public Paradigm Paradigm { get; set; }
    }
}