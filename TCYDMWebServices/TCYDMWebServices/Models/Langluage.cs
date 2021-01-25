using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.Models
{
    public class Langluage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string LangluageName { get; set; }
        public string ValueKey { get; set; }
    }
}
