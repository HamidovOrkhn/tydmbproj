using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCYDMWebServices.Data;
using TCYDMWebServices.DTO;
using TCYDMWebServices.Repositories;
using TCYDMWebServices.Repositories.Enums;
using TCYDMWebServices.Repositories.Filters;
using CryptoHelper;
using TCYDMWebServices.Repositories.Abstracts;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using TCYDMWebServices.Models;
using TCYDMWebServices.Lib;

namespace TCYDMWebServices.Controllers.V1
{
    [Validator]
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly ITransactions<UserDTO> _userService;
        private readonly ITransactions<OnlineQueryDTO> _onlineQueryService;
        private readonly IConfiguration _configuration;
        public UsersController
        (
            DatabaseContext db, 
            ITransactions<UserDTO> userRepos,
            IConfiguration config,
            ITransactions<OnlineQueryDTO> onlineRepos
        )
        {
            _db = db;
            _userService = userRepos;
            _configuration = config;
            _onlineQueryService = onlineRepos;

        }       

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDTO request)
        {
            #region FunctionBody
            bool existEmail = _db.Users.Any(a=>a.Email == request.Email);
            if (existEmail)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.AlreadyExists,message:"This Email is exists"));
            }
            bool existPhone = _db.Users.Any(a => a.PhoneNumber == request.PhoneNumber);
            if (existPhone)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.AlreadyExists, message: "This Phone Number is exists"));
            }
            string hashedPassword = Crypto.HashPassword(request.Password);
            string pKey = Hasher.EncryptString(request.Password, _configuration["Jwt:Key"]);
            string token = Guid.NewGuid().ToString();
            _db.Users.Add(new User
            {
                CountryId = request.CountryId,
                Surname = request.Surname,
                Email = request.Email,
                Name = request.Name,
                Password = hashedPassword,
                PhoneNumber = request.PhoneNumber,
                RegionId = request.RegionId,
                TCNo = request.TCNo,
                BornYear = request.BornYear,
                SexId = request.SexId,
                PKey = pKey,
                Token = token
            });
            _db.SaveChanges();
            return StatusCode(200, new ReturnMessage(message:"User Created",data:new { Token = token, Password = hashedPassword }));
            #endregion
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin request)
        {
            #region FunctionBody
            bool existEmail = _db.Users.Any(a => a.Email == request.Identification);
            bool existPhone = _db.Users.Any(a => a.PhoneNumber == request.Identification);
            if (!existEmail && !existPhone)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.WrongUser, message: "This User is not exists"));
            }
            var user = _db.Users.FirstOrDefault(a => a.Email == request.Identification || a.PhoneNumber == request.Identification);
            if (!Crypto.VerifyHashedPassword(user.Password,request.Password))
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.WrongPassword, message: "Wrong Password"));
            }
            if (user.IsConfirmed == 0)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NeedConfirmation, message: "Need Confirmation"));
            }
            #region Jwt created and Refresh token updated
            var claim = new[] { new Claim(ClaimTypes.Name, user.Name) };
            var symmetric = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signing = new SigningCredentials(symmetric, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(10),
                claims: claim,
                signingCredentials: signing
                );

             user.Token = Guid.NewGuid().ToString();
            _db.Users.Update(user);
            _db.SaveChanges();
            user.Password = null;
            #endregion
            return Ok(new ReturnMessage(
                data: new
                {
                    jwtToken = new JwtSecurityTokenHandler().WriteToken(token),
                    userData = user
                }
                ));
            #endregion
        }
        [Authorize]
        [HttpPut("update/{Id}")]
        public IActionResult Update([FromBody] UserDTO request, int Id)
        {
            #region FunctionBody
            bool exist = _db.Users.Any(c => c.Id == Id);
            if (!exist)
            {
                return StatusCode(400,new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound));
            }
            string hashed = Crypto.HashPassword(request.Password);
            string pKey = Hasher.EncryptString(request.Password, _configuration["Jwt:Key"]);
            request.Password = hashed;
            request.PKey = pKey;
            List<User> alreadyExist = _db.Users.Where(a => a.PhoneNumber == request.PhoneNumber || a.Email == request.Email).ToList();
            if (alreadyExist.Count > 1)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.AlreadyExists, message: "This credentials is used by another account"));
            }
            bool IsExisted = alreadyExist.Any(b=>b.Id == Id);
            if (!IsExisted)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.AlreadyExists, message: "This credentials is used by another account"));
            }
            bool IsUpdated = _userService.Update(request, Id);
            if (!IsUpdated)
            {
                return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal));
            }
            return Ok(new ReturnMessage());
            #endregion
        }
        //[Authorize]
        [HttpPost("online_query")]
        public IActionResult GetOnlineQuery([FromBody] OnlineQueryDTO request)
        {
            #region FunctionBody
            bool existedQuery = _db.OnlineQueries.Any(c => c.UserId == request.UserId);
            if (existedQuery)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.UnfinishedQuery));
            }
            bool existedDate = _db.OnlineQueries.Any(a => a.ServiceDate == request.ServiceDate);
            if (existedDate)
            {
                return StatusCode(400,new ReturnErrorMessage((int)ErrorTypes.Errors.ExistedTime));
            }
            request.StartDate = DateTime.Now;
            int datecompare = DateTime.Compare(request.StartDate, request.ServiceDate);
            if (datecompare>=0)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.ValidationFailed));
            }
            OnlineQuery query = new OnlineQuery();
            query.StartDate = request.StartDate;
            query.ServiceDate = request.ServiceDate;
            query.ServiceId = request.ServiceId;
            query.UserId = request.UserId;
            query.Info = request.Info;
            List<PDFClass> pdfcls = new List<PDFClass>();   
            if (request.Files !=null)
            {
                if (request.Files.Count > 0)
                {
                    foreach (var item in request.Files)
                    {
                        pdfcls.Add(new PDFClass { PDFName = item.PDFName });
                    }
                }
            }
            query.PdfClasses = pdfcls;
            _db.OnlineQueries.Add(query);

            _db.SaveChanges();
            return Ok(new ReturnMessage());
            #endregion
        }
        [HttpDelete("delete_existed_query/{Id}")]
        public IActionResult DeleteOnlineQuery(int Id)
        {
            #region FunctionBody
            var onlineQuery = _onlineQueryService.Get(Id);
            if (onlineQuery == null)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound));
            }        
            bool IsSucceed = _onlineQueryService.Delete(onlineQuery);
            if (!IsSucceed)
            {
                return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal,code:500));
            }
            return Ok(new ReturnMessage());
            #endregion
        }
        [HttpGet("refresh/{refreshToken}")]
        public object RefreshToken(string refreshToken)
        {
            #region FunctionBody
            User user = _db.Users.FirstOrDefault(a => a.Token == refreshToken);
            if (user== null)
            {
                return BadRequest();
            }
            var claim = new[] { new Claim(ClaimTypes.Name, user.Name) };
            var symmetric = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signing = new SigningCredentials(symmetric, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(10),
                claims: claim,
                signingCredentials: signing
                );
            //user.Token = Guid.NewGuid().ToString();

            //_db.SaveChanges();
            return new TokenResponse { token = user.Token, jwtToken = new JwtSecurityTokenHandler().WriteToken(token) };
            #endregion
        }
        [HttpGet("getuser/{Id}")]
        public IActionResult GetUser(int Id)
        {
            #region FunctionBody
            var userData = (from user in _db.Users
                            join region in _db.Regions on user.RegionId equals region.Id
                            join country in _db.Countries on user.CountryId equals country.Id
                            join sex in _db.Genders on user.SexId equals sex.Id
                            where user.Id == Id
                            select new
                            {
                                Region = region.Name,
                                Country = country.Name,
                                Name = user.Name,
                                Surname = user.Surname,
                                BornYear = user.BornYear,
                                Sex = sex.Name,
                                TcNo = user.TCNo,
                                Email = user.Email,
                                Phone = user.PhoneNumber
                            }).FirstOrDefault();
            return Ok(new ReturnMessage(userData));
            #endregion
        }
        [HttpGet("getuser/raw/{Id}")]
        public IActionResult GetUserRaw(int Id)
        {
            #region FunctionBody
            User user = _db.Users.Where(a => a.Id == Id).FirstOrDefault();
            if (user==null)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound));
            }
            try
            {
                user.Token = null;
                string decryptedPkey = Hasher.DecryptString(user.PKey, _configuration["Jwt:Key"]);
                user.PKey = null;
                user.Password = decryptedPkey;
                return Ok(new ReturnMessage(user));
            }
            catch (Exception x)
            {
                return StatusCode(500,new ReturnErrorMessage((int)ErrorTypes.Errors.Internal,message:x.Message));
            }
            #endregion
        }
        [HttpPost("confirmuser")]
        public IActionResult ConfirmUser([FromBody] EmailConfirmationDTO request)
        {
            #region FunctionBody
            var existedUser = _db.Users.Where(a => a.Token == request.Token).FirstOrDefault();
            
            if (existedUser.Token != request.Token)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound));
            }
            if (existedUser.IsConfirmed != 0)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound));
            }
            //existedUser.Token = Guid.NewGuid().ToString();
            existedUser.IsConfirmed = 1;
            _db.SaveChanges();
            return Ok(new ReturnMessage());
            #endregion
        }
        [HttpPost("getusertoken")]
        public IActionResult GetUserToken([FromBody] IdentityDTO request)
        {
            #region FunctionBody
            var existedUser = _db.Users.Where(a => a.Email == request.Identification || a.PhoneNumber == request.Identification).FirstOrDefault();
            if (existedUser is null)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.WrongUser));
            }
            if (existedUser.IsConfirmed == 0)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NeedConfirmation));
            }
            return Ok(new ReturnMessage(data:new {Token = existedUser.Token, Password = existedUser.Password,Email = existedUser.Email,Name = existedUser.Name}));
            #endregion
        }

        [HttpPost("confirmuser_forgotpassword")]
        public IActionResult ConfirmUserForgotPassword([FromBody] EmailConfirmationDTO request)
        {
            #region FunctionBody
            var existedUser = _db.Users.Where(a => a.Password == request.Password && a.Token == request.Token).FirstOrDefault();
            if (existedUser is null)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound));
            }
            if (existedUser.IsConfirmed == 0)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NeedConfirmation));
            }
            return Ok(new ReturnMessage());
            #endregion
        }
        [HttpPost("change_password")]
        public IActionResult ChangePassword([FromBody] ChangePassword request)
        {
            var existedUser = _db.Users.Where(a=>a.Token == request.uk).FirstOrDefault();
            if (existedUser is null)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound));
            }
            if (existedUser.IsConfirmed == 0)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NeedConfirmation));
            }
            existedUser.Token = Guid.NewGuid().ToString();
            existedUser.Password = Crypto.HashPassword(request.Password);
            existedUser.PKey = Hasher.EncryptString(request.Password, _configuration["Jwt:Key"]);
            _db.SaveChanges();
            return Ok(new ReturnMessage());
        }












    }
}
