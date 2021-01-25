using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using TCYDMWebApp.DTO;
using TCYDMWebApp.Filters;
using TCYDMWebApp.Libs;
using TCYDMWebApp.Repositories.Lang;
using TCYDMWebApp.ViewModels;
using TCYDMWebServices.Repositories;

namespace TCYDMWebApp.Controllers
{
    [Validate]
    public class UsersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        IStringLocalizer<SharedResource> _localizer;

        public UsersController(ILogger<HomeController> logger, IConfiguration config, IStringLocalizer<SharedResource> localizer)
        {
            _logger = logger;
            _configuration = config;
            _localizer = localizer;
        }


       
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult UserLoginData([FromForm] UserLoginViewModel request)
        {
        
            UserLogin user = new UserLogin();
            user.Identification = request.Identification; 
            user.Password = request.Password;
            ServiceNode<UserLogin, LoginRespDTO> client = new ServiceNode<UserLogin, LoginRespDTO>(_configuration["Api-Key"],_localizer);
            ReturnMessage<LoginRespDTO> response = client.PostClient(request, "/api/v1/users/login");
            if (response.IsCatched == 1)
            {
                ModelState.AddModelError("Identification", response.Message);
                return View("UserLogin",request);
            }
            var UserData = response.Data.userData;
            if (request.RememberMe)
            {
                Response.Cookies.Append("UserKey", UserData.id.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("email", UserData.email.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("countryId", UserData.countryId.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("regionId", UserData.regionId.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("name", UserData.name, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("surname", UserData.surname, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("tcNo", UserData.tcNo, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("refreshToken", UserData.token, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("jwtToken", response.Data.jwtToken, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMinutes(1) });
               HttpContext.Session.SetString("JwtSession", response.Data.jwtToken);

            }
            else
            {
                Response.Cookies.Append("UserKey", UserData.id.ToString());
                Response.Cookies.Append("email", UserData.email.ToString());
                Response.Cookies.Append("countryId", UserData.countryId.ToString());
                Response.Cookies.Append("regionId", UserData.regionId.ToString());
                Response.Cookies.Append("name", UserData.name);
                Response.Cookies.Append("surname", UserData.surname);
                Response.Cookies.Append("tcNo", UserData.tcNo);
                Response.Cookies.Append("refreshToken", UserData.token,new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("jwtToken", response.Data.jwtToken, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMinutes(1) });
                HttpContext.Session.SetString("JwtSession", response.Data.jwtToken);
            }
            
        
            return RedirectToAction("Privacy", "Home");

        }

    }
}
