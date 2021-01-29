using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebApp.DTO;

namespace TCYDMWebApp.ViewModels
{
    public class IndexViewModel
    {
        public List<OurServicesDTO> Services { get; set; }
        public ContactUsDTO ContactUs { get; set; }
    }
}
