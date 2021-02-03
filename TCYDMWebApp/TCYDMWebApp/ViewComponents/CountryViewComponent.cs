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
    public class CountryViewComponent:ViewComponent
    {
        private readonly HttpClient _fc;
        public CountryViewComponent(IHttpClientFactory fc)
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

            List<CountryDTO> model = new ServiceNode<object, List<CountryDTO>>(_fc)
           .GetClient("/api/lang/get/country/" + langId).Data;


            return View(model);
        }
    }
}
