using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.Repositories
{
    public class ReturnMessage
    {
        public int Code { get; set; } = 200;
        public string Message { get; set; }
        public int IsCatched { get; set; } = 0;
        public object Data { get; set; }

    }
}
