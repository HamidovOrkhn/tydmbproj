using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.Models
{
    public class User
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country Countries { get; set; }
        public int RegionId { get; set; }
        public Region Regions { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Surname { get; set; }
        [MaxLength(200)]
        public string TCNo { get; set; }
        [Required]
        [MaxLength(200)]
        [EmailAddress]

        public string Email { get; set; }
        public int SexId { get; set; }
        [Required]
        public DateTime BornYear { get; set; }
        [Required]
        [MaxLength(200)]
        [Phone]
        public string  PhoneNumber { get; set; }
        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
        
        [MaxLength(200)]
        public string Token { get; set; }
        public string PKey { get; set; }
        public int IsConfirmed { get; set; }

    }
}
