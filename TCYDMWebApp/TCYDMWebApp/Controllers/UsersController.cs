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
using TCYDMWebApp.Helper;
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
                TempData["ServerResponseError"] = response.Message;
                return RedirectToAction("UserEdit");
            }
            #endregion
            return Redirect("/");
        }
        [HttpPost]
        public IActionResult UserRegister([FromForm] UserDTO request)
        {
            #region Register Body
            ReturnMessage<EmailConfirmationDTO> response = new ServiceNode<UserDTO, EmailConfirmationDTO>(_localizer, _fc).PostClient(request, "/api/v1/users/register");
            if (response.IsCatched == 1)
            {
                TempData["ServerResponseError"] = response.Message;
                return RedirectToAction("Login");
            }
            TempData["SuccessResponse"] =_localizer["We send confirmation email to your email adress, please confirm it is actually your email.After confirmation you can access your account"].ToString();
            #region SendConfirmationEmail
            var configUrl = _configuration["BaseUrl"] + $"/users/userconfirm?uk={response.Data.Token}&&pk={response.Data.Password}";
            MailSender.SendEmail(
             "Orxan Hemidov",
             "orxan.hamidov.orxan.hamidov@mail.ru",
              request.Name,
              request.Email,
             "Email Confirmation",
              "<a href ="+configUrl+">Confirm email</a>",
             "orxan.hamidov.orxan.hamidov@mail.ru",
             "o1o2o3o4o5o6o7o8o9o10"
             );
            #endregion
            #endregion
            return RedirectToAction("Login","Users");
        }

        [HttpGet]
        public IActionResult UserConfirm([FromQuery(Name ="uk")] string uk, [FromQuery(Name ="pk")] string pk)
        {
            #region Get User Confirmation Params
            EmailConfirmationDTO configParams = new EmailConfirmationDTO();
            configParams.Password = pk;
            configParams.Token = uk;
            ReturnMessage<object> response = new ServiceNode<EmailConfirmationDTO, object>(_localizer,_fc).PostClient(configParams, "/api/v1/users/confirmuser");
            if (response.IsCatched == 1)
            {
                return Redirect("/");
            }
            #endregion
            return RedirectToAction("Login", "Users");
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
                TempData["ServerResponseError"] = response.Message;
                return RedirectToAction("Login");
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
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPasswordData([FromForm] IdentityDTO request)
        {
            ReturnMessage<ForgotPasswordDTO> response = new ServiceNode<IdentityDTO, ForgotPasswordDTO>(_localizer,_fc).PostClient(request,"/api/v1/users/getusertoken");
            if (response.IsCatched == 1)
            {
                TempData["ServerResponseError"] = response.Message;
                return RedirectToAction("ForgotPassword");
            }
            TempData["SuccessResponse"] = _localizer["We send password restore link to your email, please check your email adress"].ToString();
            #region SendRestoreEmail
            var configUrl = _configuration["BaseUrl"] + $"/users/restore?uk={response.Data.Token}&&pk={response.Data.Password}";
            MailSender.SendEmail(
             "Orxan Hemidov",
             "orxan.hamidov.orxan.hamidov@mail.ru",
              response.Data.Name,
              response.Data.Email,
             "Email Confirmation",
              "<a href =" + configUrl + ">Restore account</a>",
             "orxan.hamidov.orxan.hamidov@mail.ru",
             "o1o2o3o4o5o6o7o8o9o10"
             );
            #endregion
            return RedirectToAction("Login", "Users");

        }
        [HttpGet]
        public IActionResult Restore([FromQuery(Name = "uk")] string uk, [FromQuery(Name = "pk")] string pk)
        {
            EmailConfirmationDTO configParams = new EmailConfirmationDTO();
            configParams.Password = pk;
            configParams.Token = uk;
            ReturnMessage<object> response = new ServiceNode<EmailConfirmationDTO, object>(_localizer,_fc).PostClient(configParams, "/api/v1/users/confirmuser_forgotpassword");
            if (response.IsCatched == 1)
            {
                return Redirect("/");
            }
            return RedirectToAction("ChangePassword", "Users",new { uk = configParams.Token});
        }
        [HttpGet]
        public IActionResult ChangePassword([FromQuery(Name = "uk")] string uk)
        {
            TempData["uk"] = uk;
            return View();
        }
        [HttpPost]
        public IActionResult ChangePasswordData([FromForm] ChangePassword request)
        {
           
            ReturnMessage<object> response = new ServiceNode<ChangePassword, object>(_localizer,_fc).PostClient(request, "/api/v1/users/change_password");
            if (response.IsCatched == 1)
            {
                TempData["ServerResponseError"] = response.Message;
                return RedirectToAction("ChangePassword");
            }
            TempData["SuccessResponse"]= _localizer["Your Password Successfully Changed"].ToString();
            return RedirectToAction("Login", "Users");
        }




    }
}
