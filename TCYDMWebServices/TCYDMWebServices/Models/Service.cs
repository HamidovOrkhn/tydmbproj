using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
    }
}
