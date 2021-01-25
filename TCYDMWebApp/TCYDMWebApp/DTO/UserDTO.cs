using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [Display(Prompt = "Select Country")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Region is required")]
        [Display(Prompt = "Select Region")]
        public int RegionId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(200, ErrorMessage = "Max lenght limit is 200")]
        [Display(Prompt = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(200, ErrorMessage = "Max lenght limit is 200")]
        [Display(Prompt = "Surname")]
        public string Surname { get; set; }
        [MaxLength(200, ErrorMessage = "Max lenght limit is 200")]
        [Display(Prompt = "Personal ID")]
        public string TCNo { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(200, ErrorMessage = "Max lenght limit is 200")]
        [EmailAddress(ErrorMessage = "Email must be a valid email")]
        [Display(Prompt = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [Display(Prompt = "Select Gender")]
        public int SexId { get; set; }
        [Required(ErrorMessage = "Year of birth is required")]
        [Display(Prompt = "Select birth year")]
        public DateTime BornYear { get; set; }
        [Required(ErrorMessage ="Phone number is required")]
        [MaxLength(200,ErrorMessage ="Max lenght limit is 200")]
        [Phone(ErrorMessage ="Phone number must be a valid number")]
        [Display(Prompt = "Phone number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100,MinimumLength = 6,ErrorMessage ="Minimum password lenght must be 6 characters")]
        [MaxLength(200, ErrorMessage = "Max lenght limit is 200")]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
    }
}
