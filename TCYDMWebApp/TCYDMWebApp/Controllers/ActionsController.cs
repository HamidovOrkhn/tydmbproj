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
using TCYDMWebApp.Models;
using TCYDMWebApp.Repositories.Lang;
using TCYDMWebApp.ViewModels;
using TCYDMWebServices.DTO;
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
        public IActionResult GetOnlineTurn([Bind("ServiceId,Info,ServiceDate,Files,FileNumber,ServiceTime")] OnlineQueryViewModel request)
        {
            #region Service Prosess
            string parsedTime = request.ServiceDate.ToString("yyyy-MM-dd") + " " + request.ServiceTime;
            DateTime time = Convert.ToDateTime(parsedTime);
            var UserId = Convert.ToInt32(Request.Cookies["UserKey"]);
            OnlineQueryDTO data = new OnlineQueryDTO();
            data.UserId = UserId;
            data.Info = request.Info;
            data.ServiceDate = request.ServiceDate;
            data.ServiceId = request.ServiceId;
            data.ServiceDate = time;
            data.StartDate = DateTime.Now;
            int datecompare = DateTime.Compare(data.StartDate, request.ServiceDate);
            if (datecompare >= 0)
            {
                TempData["ServerResponseError"] = _localizer["Please select valid hour"].ToString();
                return RedirectToAction("OnlineTurn");
            }
            List<PDFDTO> files = new List<PDFDTO>();
            if (request.Files != null)
            {
                if (request.FileNumber != request.Files.Count)
                {
                    TempData["ServerResponseError"] = _localizer["Please send all required files, because if files not send operation will be not succeeded."].ToString();
                    return RedirectToAction("OnlineTurn");
                }
                for (int i = 0; i < request.Files.Count; i++)
                {
                    var filename = FileManager.IFormSaveLocal(request.Files[i], "PDFFiles");
                    files.Add(new PDFDTO { PDFName = filename });
                }
                data.Files = files;
            }
            ReturnMessage<object> response = new ServiceNode<OnlineQueryDTO, object>(_localizer, _fc)
                .PostClient(data, "/api/v1/users/online_query", HttpContext.Session.GetString("JwtSession"));
            if (response.IsCatched == 1)
            {
                TempData["ServerResponseError"] = response.Message;
                return View("OnlineTurn");
            }
            #endregion
            TempData["SuccessResponse"] = "Success";
            return Redirect("/");
        }
       

    }
}
