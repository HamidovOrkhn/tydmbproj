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
        private readonly IHttpClientFactory _fc;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IStringLocalizer<SharedResource> localizer, IHttpClientFactory fc)
        {
            _logger = logger;
            _configuration = config;
            _localizer = localizer;
            _fc = fc;

        }
      
        [TestFilter]
        public IActionResult Test1()
        {
            return Ok(Request.Cookies["TestCookie"]);
        }
       
        public IActionResult Index()
        {
            int langId = 1;
           
            if (Request.Cookies["LangKey"]!= null)
            {
                langId = Convert.ToInt32(Request.Cookies["LangKey"]);
            }
            List<OurServicesDTO> services = new List<OurServicesDTO>();
            ContactUsDTO contactus = new ContactUsDTO();
            Task tsk1 = Task.Factory.StartNew(() =>
            {
                 services = new ServiceNode<object, List<OurServicesDTO>>(_fc)
                .GetClient("/api/v1/OurServices/OurServicesGet/" + langId).Data;
            });
            Task tsk2 = Task.Factory.StartNew(() =>
            {
                 contactus = new ServiceNode<object, ContactUsDTO>(_fc)
                .GetClient("/api/v1/ContactUs/ContactUsGet/" + langId).Data;
            });
            Parallel.Invoke();
            tsk1.Wait();
            tsk2.Wait();
            IndexViewModel model = new IndexViewModel();
            model.ContactUs = contactus;
            model.Services = services;

            return View(model);
        }
        /// <summary>
        /// SILMEYIN
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            Response.Cookies.Delete("refreshToken");
            Response.Cookies.Delete("jwtToken");
            Response.Cookies.Delete("UserKey");
            Response.Cookies.Delete("TestCookie");
            return Ok("loggged out");
        }
        /// <summary>
        /// SILMEYIN
        /// </summary>
        /// <returns></returns>
        [RefreshApiToken]
        public IActionResult Privacy()
        {
            var data = new ServiceNode<object, string>(_fc).GetClient("/testapi", token: HttpContext.Session.GetString("JwtSession"));
            ViewData["apistring"] = data.Data;
            return View();
        }
        /// <summary>
        /// SILMEYIN
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
