using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebServices.Data;
using TCYDMWebServices.DTO;
using TCYDMWebServices.Models;
using TCYDMWebServices.Repositories.Abstracts;

namespace TCYDMWebServices.Repositories.Repos
{
    public class OnlineQueryRepos : ITransactions<OnlineQueryDTO>
    {
        public readonly DatabaseContext _db;
        public OnlineQueryRepos(DatabaseContext db)
        {
            _db = db;
        }
        public bool Add(OnlineQueryDTO obj)
        {
            try
            {
                _db.OnlineQueries.Add(new OnlineQuery
                {
                    Info = obj.Info,
                    ServiceDate = obj.ServiceDate,
                    ServiceId = obj.ServiceId,
                    UserId = obj.UserId,
                    StartDate = obj.StartDate
                    
                });

                _db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(OnlineQueryDTO obj)
        {
            try
            {
                _db.OnlineQueries.Remove(new OnlineQuery
                {
                    Id = obj.Id,
                    Info = obj.Info,
                    ServiceDate = obj.ServiceDate,
                    ServiceId = obj.ServiceId,
                    UserId = obj.UserId,
                    StartDate = obj.StartDate
                });
                _db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public OnlineQueryDTO Get(int Id)
        {   
           return _db.OnlineQueries.Where(a => a.UserId == Id).Select(a => new OnlineQueryDTO { 
               Id = a.Id,
               Info = a.Info, 
               ServiceId = a.ServiceId,
               ServiceDate = a.ServiceDate,
               StartDate = a.StartDate,
               UserId = a.UserId}).FirstOrDefault();    
        }

        public List<OnlineQueryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(OnlineQueryDTO obj, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
