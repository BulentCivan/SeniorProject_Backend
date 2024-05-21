using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Test
{
    public class TestResultResponseDto
    {
        public int Result{ get; set; } 
        public List<int> Questions { get; set; } = new List<int>();
        public List<int> Answers { get; set; } = new List<int>();
    }
}