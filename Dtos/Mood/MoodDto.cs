using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Mood
{
    public class MoodDto
    {
        public int Id { get; set; }
        public int mood { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Today;
    }
}