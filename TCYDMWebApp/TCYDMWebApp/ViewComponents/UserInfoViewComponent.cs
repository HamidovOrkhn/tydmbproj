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
    public class UserInfoViewComponent:ViewComponent
    {
        private readonly HttpClient _fc;
        public UserInfoViewComponent(IHttpClientFactory fc)
        {
            _fc = fc.CreateClient(name: "ApiRequests");
        }
        public IViewComponentResult Invoke()
        {
            int langId = 1;

            if (Request.Cookies["LangKey"] != null)
            {
                langId = Convert.ToInt32(Request.Cookies["LangKey"]);
            }



            var UserId = Convert.ToInt32(Request.Cookies["UserKey"]);

            UserDataDTO model = new ServiceNode<object, UserDataDTO>(_fc)
            .GetClient("/api/v1/users/getuser/" + UserId).Data;


            return View(model);
        }

    }
}
