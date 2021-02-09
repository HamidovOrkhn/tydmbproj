using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TCYDMWebServices.Models
{
    public class OnlineQuery
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public Service Service { get; set; }
        [Required]
        public DateTime ServiceDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public string Info { get; set; }
        public List<PDFClass> PdfClasses { get; set; }

    }
}
