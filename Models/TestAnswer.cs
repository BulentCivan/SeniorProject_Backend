using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("TestAnswers")]
    public class TestAnswer
    {
        public int Id { get; set; }
        public int Question { get; set; }
        public int Answer { get; set; }
        public int TestId { get; set; }

    }
}