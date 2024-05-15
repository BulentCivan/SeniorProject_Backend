using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("UserMoods")]
    public class UserMood
    {
        public string AppUserId { get; set; }
        public int MoodId { get; set;}
        public AppUser AppUser { get; set; }
        public Mood Mood { get; set; }
    }
}