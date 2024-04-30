using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account
{
    public class LoginResponseDto
    {
        public string Token { get; set; }

        public int ProgressLevel { get;  set; }
    }
}