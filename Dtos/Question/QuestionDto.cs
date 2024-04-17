using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Question
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public required string Type { get; set; } 
        public int Answer { get; set; }
        public int? TestId { get; set; }
        //navigation prop
    }
}