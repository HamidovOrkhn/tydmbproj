using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.DTO
{
    public class PDFDTO
    {
        public string PDFName { get; set; }
        [NotMapped]
        public IFormFile FileData { get; set; }
        public long QueryId { get; set; }
    }
}
