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
    public class UserEditViewComponent:ViewComponent
    {
        private readonly HttpClient _fc;
        public UserEditViewComponent(IHttpClientFactory fc)
        {
            _fc = fc.CreateClient(name: "ApiRequests");
        }
        public IViewComponentResult Invoke()
        {
            var UserId = Convert.ToInt32(Request.Cookies["UserKey"]);

            UserDTO model = new ServiceNode<object, UserDTO>(_fc)
            .GetClient("/api/v1/users/getuser/raw/" + UserId).Data;


            return View(model);
        }
    }
}
