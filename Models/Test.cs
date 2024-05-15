using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Tests")]
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Result{ get; set; } 
        public int ResultId { get; set;}

        public List<TestQuestion> TestQuestions { get; set; } = new List<TestQuestion>();


    }
}