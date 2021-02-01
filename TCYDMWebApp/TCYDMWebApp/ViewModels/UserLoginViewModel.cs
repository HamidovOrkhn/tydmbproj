using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "You must type Email or Password")]
        [Display(Prompt = "Your Email or Phone number")]
        [MaxLength(50, ErrorMessage = "Email or Phone number max length must be 100")]
        public string Identification { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Minimum password lenght must be 6 characters")]
        [MaxLength(200, ErrorMessage = "Max lenght limit is 200")]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
     
    }
}
