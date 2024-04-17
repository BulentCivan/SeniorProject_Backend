using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account
{
    public class RegisterDto
    {
        public string? UserName {get; set;} 
        public string? UserSurname {get; set;} 
        public int? Age {get; set;}

        public string? Password {get; set;}
        [EmailAddress]
        public string? Email {get; set;} 
    }
}