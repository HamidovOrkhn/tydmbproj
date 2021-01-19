using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.Repositories
{
    public class ReturnErrorMessage
    {
        public int Code { get; set; } = 400;
        public string Message { get; set; } = "Some misunderstanding occured";
        public int IsCatched { get; set; } = 1;
        public int ErrorType { get; set; }
        public object Data { get; set; }
    }
}
