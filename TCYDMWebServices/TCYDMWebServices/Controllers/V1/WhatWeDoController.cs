using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebServices.Data;
using TCYDMWebServices.DTO;
using TCYDMWebServices.Repositories;
using TCYDMWebServices.Repositories.Filters;
using TCYDMWebServices.Repositories.Enums;
using TCYDMWebServices.Repositories.Repos;
using TCYDMWebServices.Models;
using TCYDMWebServices.Repositories.Abstracts;

namespace TCYDMWebServices.Controllers.V1
{
    [Validator]
    [Route("api/v1/WhatWeDo")]
    [ApiController]
    public class WhatWeDoController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly ITransactions<WhatWeDoDTO> _wwd;
        public WhatWeDoController(DatabaseContext db, ITransactions<WhatWeDoDTO> wwd)
        {
            _wwd = wwd;
            _db = db;
        }
        [HttpGet("WhatWeDoGet/{langId}")]
        public IActionResult WhatWeDoGet(int langId)
        {
            return Ok(new ReturnMessage(_db.WhatWeDos.Where(a=>a.LanguageId == langId).FirstOrDefault()));
        }

        [HttpPost("WhatWeDoAdd")]
        public IActionResult WhatWeDoAdd([FromBody]WhatWeDoDTO request)
        {
            #region FunctionBody
            bool langluageid = _db.WhatWeDos.Any(t => t.LanguageId == request.LanguageId);
                if(langluageid)
                {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.AlreadyExists, message: "This is exists"));
                }
            bool data = _wwd.Add(request);
            if(data)
            {
                return StatusCode(200, new ReturnMessage(message: "Created"));

            }
            return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal, code: 500));
            #endregion
        }

        [HttpDelete("WhatWeDoDelete")]
        public IActionResult WhatWeDoDelete( int id)
        {
            bool datafound = _db.WhatWeDos.Any(t=>t.Id==id);
            if(!datafound)
            {
                return StatusCode(400,new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound,message:"NotFound"));
            }
            WhatWeDo data = _db.WhatWeDos.Find(id);
            WhatWeDoDTO dto = new WhatWeDoDTO
            {
                Id = id,
                Content = data.Content,
                LanguageId = data.LanguageId
            };
            bool request = _wwd.Delete(dto);
            if(request)
            {
                return Ok(new ReturnMessage(200,message:"Success"));
            }
            return StatusCode(500, new ReturnErrorMessage((int)ErrorTypes.Errors.Internal, message: "Internal server error"));
        }

        [HttpPut("WhatWeDoUpdate")]
        public IActionResult WhatWeDoUpdate([FromBody]WhatWeDoDTO request)
        {
            bool data = _db.WhatWeDos.Any(t => t.Id == request.Id);
            if(!data)
            {
                return StatusCode(400, new ReturnErrorMessage((int)ErrorTypes.Errors.NotFound,message:"NotFound"));
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
