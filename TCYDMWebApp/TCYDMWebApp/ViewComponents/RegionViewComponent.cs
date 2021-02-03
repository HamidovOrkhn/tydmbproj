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
    public class RegionViewComponent:ViewComponent
    {
        private readonly HttpClient _fc;
        public RegionViewComponent(IHttpClientFactory fc)
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

            List<RegionDTO> model = new ServiceNode<object, List<RegionDTO>>(_fc)
           .GetClient("/api/lang/get/region/" + langId).Data;


            return View(model);
        }
    }
}
