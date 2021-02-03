using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TCYDMWebServices.Models
{
    public class Region
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public List<User> Users { get; set; }
    }
}
