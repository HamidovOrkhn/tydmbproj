using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.DTO
{
    public class OurServicesDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Range(1, 10)]
        public int NeedsAdittion { get; set; }
        [Range(1, 5)]
        public int NeedsPayment { get; set; }
        [Range(1, 3)]
        public int IsLocal { get; set; }
    }
}
