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
    public class ContactViewComponent:ViewComponent
    {
        private readonly HttpClient _fc; 
        public ContactViewComponent(IHttpClientFactory fc)
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
            
            ContactUsDTO contactus = new ContactUsDTO();
           
          
                contactus = new ServiceNode<object, ContactUsDTO>(_fc)
               .GetClient("/api/v1/ContactUs/ContactUsGet/" + langId).Data;
          

            return View(contactus);
    }
}
}
