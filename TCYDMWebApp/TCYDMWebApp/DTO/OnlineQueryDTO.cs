using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.DTO
{
    public class OnlineQueryDTO
    {
        public long Id { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime ServiceDate { get; set; }
        public DateTime StartDate { get; set; }
        [MaxLength(256)]
        public string Info { get; set; }
    }
}
