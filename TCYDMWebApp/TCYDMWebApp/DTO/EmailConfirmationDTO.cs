using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.DTO
{
    public class EmailConfirmationDTO
    {  
        public string Token { get; set; }
        public string  Password { get; set; }      
    }
}
