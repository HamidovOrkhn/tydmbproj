using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.DTO
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Minimum password lenght must be 6 characters")]
        [MaxLength(200, ErrorMessage = "Max lenght limit is 200")]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords are not match")]
        [Display(Prompt = "Confirm Password")]
        public string Password_Compare { get; set; }
        public string uk { get; set; }
    }
}
