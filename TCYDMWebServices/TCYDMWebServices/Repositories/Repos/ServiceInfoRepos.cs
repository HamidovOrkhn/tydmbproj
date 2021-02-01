using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebServices.Data;
using TCYDMWebServices.Models;
using TCYDMWebServices.Repositories.Abstracts;

namespace TCYDMWebServices.Repositories.Repos
{
    public class ServiceInfoRepos : ITransactions<ServiceInfo>
    {
        private readonly DatabaseContext _db;
        public ServiceInfoRepos(DatabaseContext database)
        {
            _db = database;
        }
        public bool Add(ServiceInfo obj)
        {
            try
            {
                _db.ServiceInfos.Add(obj);

                _db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(ServiceInfo obj)
        {
            try
            {
                _db.ServiceInfos.Remove(obj);
                _db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ServiceInfo Get(int Id)
        {
            ServiceInfo mappeduser = new ServiceInfo();
            try
            {
                ServiceInfo service = _db.ServiceInfos.FirstOrDefault(c => c.Id == Id);
                return service;

            }
            catch (Exception)
            {
                return mappeduser;
            }


        }

        public List<ServiceInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(ServiceInfo obj, int Id)
        {
            try
            {
                ServiceInfo service = _db.ServiceInfos.Find(Id);
             
                service.Name = obj.Name;
                service.Info = obj.Info;
                service.LanguageId = obj.LanguageId;
                service.ServiceId = obj.ServiceId;
              
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
