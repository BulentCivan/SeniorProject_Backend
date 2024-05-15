using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("TestQuestions")]
    public class TestQuestion
    {
        public int TestId { get; set; }
        public int QuestionId { get; set;}
        public Test Test { get; set; }
        public Question Question { get; set; }
    }
}