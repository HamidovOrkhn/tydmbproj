using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TCYDMWebApp.DTO;
using TCYDMWebApp.Libs;

namespace TCYDMWebApp.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly HttpClient _fc;
        public FooterViewComponent(IHttpClientFactory fc)
        {
            _fc = _fc = fc.CreateClient(name: "ApiRequests");
        }
        public IViewComponentResult Invoke()
        {
            int langId = 1;

            if (Request.Cookies["LangKey"] != null)
            {
                langId = Convert.ToInt32(Request.Cookies["LangKey"]);
            }
            List<OurServicesDTO> services = new List<OurServicesDTO>();
            services = new ServiceNode<object, List<OurServicesDTO>>(_fc)
            .GetClient("/api/v1/OurServices/OurServicesGet/" + langId).Data;

            return View(services);
        }
    }
}
