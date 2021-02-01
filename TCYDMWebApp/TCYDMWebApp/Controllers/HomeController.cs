using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TCYDMWebApp.DTO;
using TCYDMWebApp.Filters;
using TCYDMWebApp.Libs;
using TCYDMWebApp.Models;
using TCYDMWebApp.Repositories.Lang;
using TCYDMWebApp.ViewModels;
using TCYDMWebServices.Repositories;

namespace TCYDMWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly HttpClient _fc;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IStringLocalizer<SharedResource> localizer, IHttpClientFactory fc)
        {
            _logger = logger;
            _configuration = config;
            _localizer = localizer;
            _fc = fc.CreateClient(name: "ApiRequests");

        }
 
       
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/home/services/{serviceId}")]
        public IActionResult ServiceInfo(int serviceId)
        {
            #region ServiceData
                        int langId = 1;

                        if (Request.Cookies["LangKey"] != null)
                        {
                            langId = Convert.ToInt32(Request.Cookies["LangKey"]);
                        }
                        OurServicesDTO prms = new OurServicesDTO();
                        ServiceInfo service = new ServiceInfo();
                        Task tsk1 = Task.Factory.StartNew(() =>
                        {
                            prms = new ServiceNode<object, OurServicesDTO>(_fc)
                           .GetClient("/api/v1/OurServices/OurServicesGetById/"+ serviceId +"/" + langId).Data;
                        });
                        Task tsk2 = Task.Factory.StartNew(() =>
                        {
                            service = new ServiceNode<object, ServiceInfo>(_fc)
                           .GetClient("/api/v1/serviceinfo/get/"+serviceId+"/" + langId).Data;
                        });
                        Parallel.Invoke();
                        tsk1.Wait();
                        tsk2.Wait();
                        ServiceInfoViewModel model = new ServiceInfoViewModel();
                        model.ServiceInfo = service;
                        model.ServiceParams = prms;
                        #endregion
            return View("ServiceInfo", model);
        }

        [HttpGet]
        public IActionResult WhatWeDo()
        {
            #region ServiceData
            int langId = 1;

            if (Request.Cookies["LangKey"] != null)
            {
                langId = Convert.ToInt32(Request.Cookies["LangKey"]);
            }

            WhatWeDoDTO model = new ServiceNode<object, WhatWeDoDTO>(_fc)
                   .GetClient("/api/v1/WhatWeDo/WhatWeDoGet/"+langId).Data;

            #endregion
            return View(model);     
        }

        [HttpGet]
        public IActionResult WhoWeAre()
        {
            #region ServiceData
            int langId = 1;

            if (Request.Cookies["LangKey"] != null)
            {
                langId = Convert.ToInt32(Request.Cookies["LangKey"]);
            }

            WhoWeAreDTO model = new ServiceNode<object, WhoWeAreDTO>(_fc)
                   .GetClient("/api/v1/WhoWeAre/WhoWeAreGet/" + langId).Data;

            #endregion
            return View(model);
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            #region ServiceData
            int langId = 1;

            if (Request.Cookies["LangKey"] != null)
            {
                langId = Convert.ToInt32(Request.Cookies["LangKey"]);
            }

            ContactUsDTO model = new ServiceNode<object, ContactUsDTO>(_fc)
           .GetClient("/api/v1/ContactUs/ContactUsGet/" + langId).Data;

            #endregion
            return View(model);
        }
        [RefreshApiToken]
        public IActionResult Privacy()
        {
            var data = new ServiceNode<object, string>(_fc).GetClient("/testapi", token: HttpContext.Session.GetString("JwtSession"));
            ViewData["apistring"] = data.Data;
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage([FromForm] LangDTO request)
        {

              
              var resp = new ServiceNode<object, Lang>(_localizer, _fc).GetClient("/api/lang/get/"+request.culture);
              Response.Cookies.Append("LangKey",resp.Data.id.ToString(),
              new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
              Response.Cookies.Append(
              CookieRequestCultureProvider.DefaultCookieName,
              CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(resp.Data.valueKey)),
              new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
          );
            
          
          

            return LocalRedirect(request.returnurl);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
