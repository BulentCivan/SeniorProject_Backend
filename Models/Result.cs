using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int? TestId { get; set; }
        //navigation prop
        public Test? Test{ get; set; }
        public double result { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

    }
}