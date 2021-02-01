using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.DTO
{
    public class WhoWeAreDTO
    {
       
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int LanguageId { get; set; }
    }
}
