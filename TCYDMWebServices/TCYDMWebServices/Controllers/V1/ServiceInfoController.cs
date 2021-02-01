using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCYDMWebServices.Data;
using TCYDMWebServices.DTO;
using TCYDMWebServices.Models;
using TCYDMWebServices.Repositories;
using TCYDMWebServices.Repositories.Abstracts;
using TCYDMWebServices.Repositories.Enums;

namespace TCYDMWebServices.Controllers.V1
{
    [Route("api/v1/serviceinfo")]
    [ApiController]
    public class ServiceInfoController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly ITransactions<ServiceInfo> _wwd;
        public ServiceInfoController(DatabaseContext db, ITransactions<ServiceInfo> wwd)
        {
            _wwd = wwd;
            _db = db;
        }
        [HttpGet("get/{langId}")]
        public IActionResult ServicesGet(int langId)
        {
            return Ok(new ReturnMessage(data: _db.ServiceInfos.Where(a => a.LanguageId == langId).ToList()));
        }
        [HttpGet("get/{serviceId}/{langId}")]
        public IActionResult ServicesGetById(int serviceId,int langId)
        {
            return Ok(new ReturnMessage(data: _db.ServiceInfos.Where(a => a.LanguageId == langId && a.ServiceId == serviceId).FirstOrDefault()));
        }
        [HttpPost("add")]
        public IActionResult ServiceInfoAdd([FromBody] ServiceInfo request)
        {
            #region FunctionBody
            bool langluagename = _db.ServiceInfos.Any(t => t.LanguageId == request.LanguageId && t.Name == request.Name);
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

        [HttpDelete("delete")]
        public IActionResult ServicesDelete(int id)
        {
            bool datafound = _db.ServiceInfos.Any(t => t.Id == id);
            if (!datafound)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound, message: "NotFound"));
            }
            ServiceInfo data = _db.ServiceInfos.Find(id);
            
            bool request = _wwd.Delete(data);
            if (request)
            {
                return Ok(new ReturnMessage(200, message: "Success"));
            }
            return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal, message: "Internal server error"));
        }

        [HttpPut("update/{id}")]
        public IActionResult ServicesUpdate([FromBody] ServiceInfo request)
        {
            bool data = _db.ServiceInfos.Any(t => t.Id == request.Id);

            if (!data)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound, message: "NotFound"));
            }
            bool langluagename = _db.ServiceInfos.Any(t => t.LanguageId == request.LanguageId && t.Name == request.Name);
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
