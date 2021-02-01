using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebServices.Data;
using TCYDMWebServices.DTO;
using TCYDMWebServices.Models;
using TCYDMWebServices.Repositories;
using TCYDMWebServices.Repositories.Abstracts;
using TCYDMWebServices.Repositories.Enums;
using TCYDMWebServices.Repositories.Filters;
using TCYDMWebServices.Repositories.Repos;

namespace TCYDMWebServices.Controllers.V1
{
    [Validator]
    [Route("api/v1/OurServices")]
    [ApiController]
    public class OurServicesController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly ITransactions<OurServicesDTO> _wwd;
        public OurServicesController(DatabaseContext db, ITransactions<OurServicesDTO> wwd)
        {
            _wwd = wwd;
            _db = db;
        }
        [HttpGet("OurServicesGet/{langId}")]
        public IActionResult OurServicesGet(int langId)
        {
            return Ok( new ReturnMessage(data: _db.Services.Where(a => a.LanguageId == langId).ToList().OrderBy(a=>a.ServiceId)));
        }
        [HttpGet("OurServicesGetById/{serviceId}/{langId}")]
        public IActionResult GetServiceById(int serviceId,int langId)
        {
            return Ok(new ReturnMessage(_db.Services.Where(a => a.LanguageId == langId && a.ServiceId == serviceId).FirstOrDefault()));
        }

        [HttpPost("OurServicesAdd")]
        public IActionResult WhatWeDoAdd([FromBody] OurServicesDTO request)
        {
            #region FunctionBody
            bool langluagename = _db.Services.Any(t => t.LanguageId == request.LanguageId && t.Name==request.Name);
            if (langluagename)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.AlreadyExists, message: "This is exists"));
            }
            bool data = _wwd.Add(request);
            if (data)
            {
                return StatusCode(200, new ReturnMessage(message: "Created"));

            }
            return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal, code: 500));
            #endregion
        }

        [HttpDelete("OurServicesDelete")]
        public IActionResult OurServicesDelete(int id)
        {
            bool datafound = _db.Services.Any(t => t.Id == id);
            if (!datafound)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound, message: "NotFound"));
            }
            Service data = _db.Services.Find(id);
            OurServicesDTO dto = new OurServicesDTO
            {
                Id = id,
                Name = data.Name,
                LanguageId = data.LanguageId
            };
            bool request = _wwd.Delete(dto);
            if (request)
            {
                return Ok(new ReturnMessage(200, message: "Success"));
            }
            return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal, message: "Internal server error"));
        }

        [HttpPut("OurServicesUpdate")]
        public IActionResult OurServicesUpdate([FromBody] OurServicesDTO request)
        {
            bool data = _db.Services.Any(t => t.Id == request.Id);

            if (!data)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound, message: "NotFound"));
            }
            bool langluagename = _db.Services.Any(t => t.LanguageId == request.LanguageId && t.Name == request.Name);
            if (langluagename)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.AlreadyExists, message: "AlreadyExists"));
            }
            bool datafinal = _wwd.Update(request, request.Id);
            if (datafinal)
            {
                return Ok(new ReturnMessage());
            }
            return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal, message: "Error Internal Server"));
        }
    }
}
