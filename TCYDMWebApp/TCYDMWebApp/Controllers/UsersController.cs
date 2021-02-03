using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly HttpClient _fc;


        public UsersController(ILogger<HomeController> logger, IConfiguration config, IStringLocalizer<SharedResource> localizer,IHttpClientFactory client)
        {
            _logger = logger;
            _configuration = config;
            _localizer = localizer;
            _fc = client.CreateClient(name:"ApiRequests");
        }


       
   
        [HttpGet]
        public IActionResult Login()
        {
            return View("UserLogin");  
        }
        [RefreshApiToken]
        [HttpGet]
        public IActionResult UserEdit()
        {
            return View();
        }
        [RefreshApiToken]
        [HttpPost]
        public IActionResult EditUserData([FromForm] UserDTO request)
        {
            #region Edit User 
            var UserId = Convert.ToInt32(Request.Cookies["UserKey"]);
            ReturnMessage<object> response = new ServiceNode<UserDTO, object>(_localizer, _fc).PutClient(request, "/api/v1/users/update/"+ UserId, HttpContext.Session.GetString("JwtSession"));
            if (response.IsCatched == 1)
            {
                ViewData["ServerResponseError"] = response.Message;
                return View("UserEdit");
            }
            #endregion
            return Redirect("/");
        }
        [HttpPost]
        public IActionResult UserRegister([FromForm] UserDTO request)
        {
            #region Register Body
            ReturnMessage<object> response = new ServiceNode<UserDTO, object>(_localizer, _fc).PostClient(request, "/api/v1/users/register");
            if (response.IsCatched == 1)
            {
                ViewData["ServerResponseError"] = response.Message;
                return View("UserLogin");
            }
            #endregion
            return RedirectToAction("Login","Users");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            #region Clear Cookies
            Response.Cookies.Delete("UserKey");
            Response.Cookies.Delete("email");
            Response.Cookies.Delete("name");
            Response.Cookies.Delete("surname");
            Response.Cookies.Delete("refreshToken");
            Response.Cookies.Delete("jwtToken");
            Response.Cookies.Delete("cId");
            Response.Cookies.Delete("rId");
            #endregion
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult UserLoginData([FromForm] UserLoginViewModel request)
        {
            #region Logged User Configuration
            UserLogin user = new UserLogin();
            user.Identification = request.Identification; 
            user.Password = request.Password;
            ServiceNode<UserLogin, LoginRespDTO> client = new ServiceNode<UserLogin, LoginRespDTO>(_localizer, _fc);
            ReturnMessage<LoginRespDTO> response = client.PostClient(request, "/api/v1/users/login");
            if (response.IsCatched == 1)
            {
                ModelState.AddModelError("ServerResponse", response.Message);
                ViewData["ServerResponseError"] = response.Message;
                return View("UserLogin");
            }
            var UserData = response.Data.userData;
            if (request.RememberMe)
            {
                Response.Cookies.Append("UserKey", UserData.id.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("email", UserData.email.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("name", UserData.name, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("surname", UserData.surname, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("cId", UserData.countryId.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("rId", UserData.regionId.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("refreshToken", UserData.token, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("jwtToken", response.Data.jwtToken, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMinutes(1) });
               HttpContext.Session.SetString("JwtSession", response.Data.jwtToken);

            }
            else
            {
                Response.Cookies.Append("UserKey", UserData.id.ToString());
                Response.Cookies.Append("email", UserData.email.ToString());
                Response.Cookies.Append("name", UserData.name);
                Response.Cookies.Append("surname", UserData.surname);
                Response.Cookies.Append("cId", UserData.countryId.ToString());
                Response.Cookies.Append("rId", UserData.regionId.ToString());
                Response.Cookies.Append("refreshToken", UserData.token,new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) });
                Response.Cookies.Append("jwtToken", response.Data.jwtToken, new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMinutes(1) });
                HttpContext.Session.SetString("JwtSession", response.Data.jwtToken);
            }
            #endregion
            return RedirectToAction("Index", "Home");
        }



    }
}
