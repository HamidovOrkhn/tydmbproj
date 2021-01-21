using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.Models
{
    public class OnlineQuery
    {
        public long Id { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public Service Service { get; set; }
        [Required]
        public DateTime ServiceDate { get; set; }
        public string Info { get; set; }
    }
}
