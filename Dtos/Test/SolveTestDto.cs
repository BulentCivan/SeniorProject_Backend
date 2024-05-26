using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Test
{
    public class SolveTestDto
    {
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public List<TestAnswerDto> Answers { get; set; }
    }
}