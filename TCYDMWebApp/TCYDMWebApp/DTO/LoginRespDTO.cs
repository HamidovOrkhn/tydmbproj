using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.DTO
{
    public class LoginRespDTO
    {
        public string jwtToken { get; set; }
        public UserData userData { get; set; }

    }
}
