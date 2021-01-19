using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.Repositories.Enums
{
    interface ErrorTypes
    {
        public enum Errors
        {
            Internal,
            NotFound,
            ValidationFailed
        }
    }
}
