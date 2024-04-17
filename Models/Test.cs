using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Result Result{ get; set; } = new Result();

        public List<Question> Questions { get; set; } = new List<Question>();


    }
}