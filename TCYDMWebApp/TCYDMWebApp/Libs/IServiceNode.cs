using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebServices.Repositories;

namespace TCYDMWebApp.Libs
{
    public interface IServiceNode
    {
        public ReturnMessage<object> DeleteClient(string url, string token = null);
        public ReturnMessage<object> GetClient(string url, string token = null);
        public ReturnMessage<object> PostClient(object data, string url, string token = null);
        public ReturnMessage<object> PutClient(object data, string url, string token = null);

    }
}
