using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.Models
{
    public class PDFClass
    {   
            public int Id { get; set; }
            public string PDFName { get; set; }
            [NotMapped]
            public IFormFile FileData { get; set; }
            [ForeignKey("Id")]
            public long OnlineQueryId { get; set; }
            public OnlineQuery OnlineQuery { get; set; }

    }
}
