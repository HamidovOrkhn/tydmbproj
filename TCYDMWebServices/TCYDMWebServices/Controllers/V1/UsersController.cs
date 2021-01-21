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

namespace TCYDMWebServices.Controllers.V1
{
    [Validator]
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly ITransactions<UserDTO> _userService;
        private readonly IConfiguration _configuration;
        public UsersController(DatabaseContext db, ITransactions<UserDTO> userRepos, IConfiguration config)
        {
            _db = db;
            _userService = userRepos;
            _configuration = config;

        }
       // [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(_db.Users.ToList());
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
            var user = new UserDTO {
                CountryId = request.CountryId,
                Email = request.Email,
                Name = request.Email,
                Surname = request.Surname,
                Password = hashedPassword,
                PhoneNumber = request.PhoneNumber,
                RegionId = request.RegionId,
                TCNo = request.TCNo
            };
            bool IsSucceed = _userService.Add(user);
            if (!IsSucceed)
            {
                return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal, code: 500));
            }
            return StatusCode(200, new ReturnMessage(message:"User Created"));
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
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound, message: "This User is not exists"));
            }
            var user = _db.Users.FirstOrDefault(a => a.Email == request.Identification || a.PhoneNumber == request.Identification);
            if (!Crypto.VerifyHashedPassword(user.Password,request.Password))
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound, message: "Wrong Password"));
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
            request.Password = hashed;
            bool IsUpdated = _userService.Update(request,Id);
            if (!IsUpdated)
            {
                return StatusCode(500,new ReturnErrorMessage((int)ErrorTypes.Errors.Internal));
            }
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
            return Ok(new ReturnMessage());
            #endregion
        }



    }
}
