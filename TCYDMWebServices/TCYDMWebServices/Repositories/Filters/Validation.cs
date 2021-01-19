using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebServices.Repositories.Enums;

namespace TCYDMWebServices.Repositories.Filters
{
    public class Validator : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Middleware Started");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var error = context.ModelState.Values;
                var key = context.ModelState.Keys;
                context.Result = new BadRequestObjectResult(
                    new ReturnErrorMessage
                    {
                        Code = 400,
                        Message = "Validation error occured",
                        ErrorType = (int)ErrorTypes.Errors.ValidationFailed,
                        Data = new
                        {
                            Error = error.Select(a => a.Errors),
                            Key = key
                        }

                      
                            
                        
                    });
            }
        }
    }
}
