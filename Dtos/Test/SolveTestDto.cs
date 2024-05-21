using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Test
{
    public class SolveTestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, int> Answers { get; set; }
    }
}