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
    [Route("api/v1/WhoWeAre")]
    [ApiController]
    public class WhoWeAreController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly ITransactions<WhoWeAreDTO> _wwd;
        public WhoWeAreController(DatabaseContext db, ITransactions<WhoWeAreDTO> wwd)
        {
            _wwd = wwd;
            _db = db;
        }
        [HttpGet("WhoWeAreGet/{langId}")]
        public IActionResult WhoWeAreGet(int langId)
        {
            return Ok(new ReturnMessage(_db.WhoWeAres.Where(a => a.LanguageId == langId).FirstOrDefault()));
        }

        [HttpPost("WhoWeAreAdd")]
        public IActionResult WhoWeAreAdd([FromBody] WhoWeAreDTO request)
        {
            #region FunctionBody
            bool langluageid = _db.WhoWeAres.Any(t => t.LanguageId == request.LanguageId);
            if (langluageid)
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

        [HttpDelete(" WhoWeAreDelete")]
        public IActionResult WhoWeAreDelete(int id)
        {
            #region FunctionBody
            bool datafound = _db.WhoWeAres.Any(t => t.Id == id);
            if (!datafound)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound, message: "NotFound"));
            }
            WhoWeAre data = _db.WhoWeAres.Find(id);
            WhoWeAreDTO dto = new WhoWeAreDTO
            {
                Id = id,
                Content = data.Content,
                LanguageId = data.LanguageId
            };
            bool request = _wwd.Delete(dto);
            if (request)
            {
                return Ok(new ReturnMessage(200, message: "Success"));
            }
            return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal, message: "Internal server error"));
            #endregion
        }

        [HttpPut("WhoWeAreUpdate")]
        public IActionResult WhoWeAreUpdate([FromBody] WhoWeAreDTO request)
        {
            #region FunctionBody
            bool data = _db.WhoWeAres.Any(t => t.Id == request.Id);
            if (!data)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound, message: "NotFound"));
            }
            bool datafinal = _wwd.Update(request, request.Id);
            if (datafinal)
            {
                return Ok(new ReturnMessage());
            }
            return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal, message: "Error Internal Server"));
            #endregion
        }
    }
}
