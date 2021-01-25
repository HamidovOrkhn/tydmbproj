using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TCYDMWebApp.DTO;

namespace TCYDMWebApp.Filters
{
    public class TestFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append("TestCookie", "fdata");
            base.OnResultExecuting(context);
        }
    }
}
