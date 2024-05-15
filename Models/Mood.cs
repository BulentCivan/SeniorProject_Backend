using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Moods")]
    public class Mood
    {
        public int Id { get; set; }
        public int mood { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Today;
        public List<UserMood> UserMoods{ get; set; } = new List<UserMood>();
    }
}