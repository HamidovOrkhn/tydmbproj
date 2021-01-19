using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.DTO
{
    public class UserDTO
    {
        [Required]
        [MaxLength(50)]
        public string Identification { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
