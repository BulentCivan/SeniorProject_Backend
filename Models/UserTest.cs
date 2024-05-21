using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("UserTests")]
    public class UserTest
    {
        public string AppUserId { get; set; }
        public int TestId { get; set;}
        public AppUser AppUser { get; set; }
        public Test Test { get; set; }
    }
}