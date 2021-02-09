using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.Models
{
    public class PDFClass
    {   
            public int Id { get; set; }
            public string? PDFName { get; set; }
            [NotMapped]
            public IFormFile? FileData { get; set; }
            public long? QueryId { get; set; }
    
    }
}
