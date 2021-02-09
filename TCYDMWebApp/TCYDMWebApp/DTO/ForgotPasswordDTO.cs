using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.DTO
{
    public class ForgotPasswordDTO:EmailConfirmationDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
