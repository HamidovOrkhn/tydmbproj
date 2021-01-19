using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebServices.Repositories.Abstracts
{
    public interface ITransations<T> where T : new()
    {
        
            bool Add(T obj);
            bool Update(T obj, int Id);
            bool Delete(T obj);
            List<T> GetAll();
            T Get(int Id);
        
    }
}
