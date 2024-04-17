using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Question;

namespace api.Dtos.Test
{
    public class TestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<QuestionDto> Questions { get; set; }
        
        
    }
}