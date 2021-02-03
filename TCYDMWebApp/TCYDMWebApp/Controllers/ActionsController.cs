using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using TCYDMWebApp.DTO;
using TCYDMWebApp.Filters;
using TCYDMWebApp.Libs;
using TCYDMWebApp.Repositories.Lang;
using TCYDMWebApp.ViewModels;
using TCYDMWebServices.Repositories;

namespace TCYDMWebApp.Controllers
{
    [RefreshApiToken]
    public class ActionsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly HttpClient _fc;

        public ActionsController(IConfiguration config, IStringLocalizer<SharedResource> localizer, IHttpClientFactory fc)
        {

            _configuration = config;
            _localizer = localizer;
            _fc = fc.CreateClient(name: "ApiRequests");

        }
        [HttpGet]
        public IActionResult OnlineTurn()
        {           
            return View();
        }
        [HttpPost]
        public IActionResult GetOnlineTurn([FromForm] OnlineQueryViewModel request)
        {
            #region Service Prosess
            var UserId = Convert.ToInt32(Request.Cookies["UserKey"]);
            OnlineQueryDTO data = new OnlineQueryDTO();
            data.UserId = UserId;
            data.Info = request.Info;
            data.ServiceDate = request.ServiceDate;
            data.ServiceId = request.ServiceId;
            ReturnMessage<object> response = new ServiceNode<OnlineQueryDTO, object>(_localizer,_fc)
                .PostClient(data,"/api/v1/users/online_query",HttpContext.Session.GetString("JwtSession"));
            if (response.IsCatched == 1)
            {
                ViewData["ServerResponseError"] = response.Message;
                return View("OnlineTurn");
            }
            #endregion
            return Redirect("/");
        }
       

    }
}
