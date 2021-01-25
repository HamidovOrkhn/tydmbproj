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
    public class OurServicesRepos: ITransactions<OurServicesDTO>
    {
        private readonly DatabaseContext _db;
        public OurServicesRepos(DatabaseContext db)
        {
            _db = db;
        }

        public bool Add(OurServicesDTO obj)
        {
            try
            {
                _db.Services.Add(new Service
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    LanguageId = obj.LanguageId
                });
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(OurServicesDTO obj)
        {
            try
            {
                Service data = _db.Services.Find(obj.Id);
                _db.Services.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public OurServicesDTO Get(int Id)
        {
            try
            {
                Service data = _db.Services.Find(Id);
                OurServicesDTO finaldata = new OurServicesDTO
                {
                    Id = data.Id,
                    Name = data.Name,
                    LanguageId = data.LanguageId
                };
                return finaldata;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<OurServicesDTO> GetAll()
        {
            return null;
        }

        public bool Update(OurServicesDTO obj, int Id)
        {
            try
            {
                Service data = _db.Services.Find(Id);
                data.Name = obj.Name;
                data.LanguageId = obj.LanguageId;
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
