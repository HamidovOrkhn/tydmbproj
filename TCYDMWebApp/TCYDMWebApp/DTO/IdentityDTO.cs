using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.DTO
{
    public class IdentityDTO
    {
        [Required(ErrorMessage = "You must type Email or Password")]
        [Display(Prompt = "Your Email or Phone number")]
        [MaxLength(50, ErrorMessage = "Email or Phone number max length must be 100")]
        public string Identification { get; set; }
    }
}
