using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Type { get; set; } 
        public int Answer { get; set; }
        public int? TestId { get; set; }
        //navigation prop
        public Test? Test{ get; set; }

    }
}