using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Profiles")]
    public class Profile
    {
        public string AppUserId { get; set; }
        public int ResultId { get; set;}
        public AppUser AppUser { get; set; }
        public Result Result { get; set; }

    }
}