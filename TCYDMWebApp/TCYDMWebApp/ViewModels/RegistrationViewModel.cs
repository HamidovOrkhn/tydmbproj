using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebApp.DTO;

namespace TCYDMWebApp.ViewModels
{
    public class RegistrationViewModel:IndexViewModel
    {
        public UserDTO Registration { get; set; }
    }
}
