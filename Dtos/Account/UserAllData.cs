using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Paradigm;
using api.Models;

namespace api.Dtos.Account
{
    public class UserAllData
    {
        public AppUser User { get; set; }
        public List<api.Models.Test> Tests { get; set; }
        public List<api.Models.Paradigm> Paradigms { get; set; }


    }
}