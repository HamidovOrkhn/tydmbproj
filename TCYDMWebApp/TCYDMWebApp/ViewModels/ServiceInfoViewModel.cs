using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebApp.DTO;
using TCYDMWebApp.Models;

namespace TCYDMWebApp.ViewModels
{
    public class ServiceInfoViewModel
    {
        public ServiceInfo ServiceInfo { get; set; }
        public OurServicesDTO ServiceParams { get; set; }
    }
}
