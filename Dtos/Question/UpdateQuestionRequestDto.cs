using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Question
{
    public class UpdateQuestionRequestDto
    {
        public string Content { get; set; } = string.Empty;
        public required string Type { get; set; } 
    }
}