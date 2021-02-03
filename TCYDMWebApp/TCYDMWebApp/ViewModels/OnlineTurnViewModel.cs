using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebApp.DTO;

namespace TCYDMWebApp.ViewModels
{
    public class OnlineTurnViewModel
    {
    
        public OnlineQueryViewModel OnlineQuery { get; set; }
        public UserDataDTO UserData { get; set; }
        public List<OurServicesDTO> Services { get; set; }
    }
}
