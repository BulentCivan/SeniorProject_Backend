using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Mood
{
    public class CreateMoodDto
    {
        public int mood { get; set; }
        public string? Content { get; set; }
    }
}