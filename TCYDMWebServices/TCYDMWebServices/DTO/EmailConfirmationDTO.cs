using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.DTO
{
    public class EmailConfirmationDTO
    {  
        public string Token { get; set; }
        public string  Password { get; set; }      
    }
}
