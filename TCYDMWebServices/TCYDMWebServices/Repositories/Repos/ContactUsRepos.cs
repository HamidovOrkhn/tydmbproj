using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCYDMWebServices.Data;
using TCYDMWebServices.DTO;
using TCYDMWebServices.Repositories.Abstracts;
using TCYDMWebServices.Models;

namespace TCYDMWebServices.Repositories.Repos
{
    public class ContactUsRepos : ITransactions<ContactUsDTO>
    {
        private readonly DatabaseContext _db;
        public ContactUsRepos(DatabaseContext db)
        {
            _db = db;
        }
        public bool Add(ContactUsDTO obj)
        {
            try
            {
                _db.ContactUss.Add(new ContactUs
                {
                    Id = obj.Id,
                    Phone = obj.Phone,
                    Content=obj.Content,
                    Adress = obj.Adress,
                    Email = obj.Email,
                    LanguageId = obj.LanguageId
                });
                _db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        public bool Delete(ContactUsDTO obj)
        {
            try
            {
                ContactUs data = _db.ContactUss.Find(obj.Id);
                _db.ContactUss.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        public ContactUsDTO Get(int Id)
        {
            try
            {
                ContactUs data = _db.ContactUss.Find(Id);
                ContactUsDTO finaldata = new ContactUsDTO
                {
                    Id = data.Id,
                    Phone = data.Phone,
                    Content=data.Content,
                    Adress = data.Adress,
                    Email = data.Email,
                    LanguageId = data.LanguageId
                };
                return finaldata;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public List<ContactUsDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(ContactUsDTO obj, int Id)
        {
            try
            {
                ContactUs data = _db.ContactUss.Find(Id);
                data.Phone = obj.Phone;
                data.Adress = obj.Adress;
                data.Content = obj.Content;
                data.Email = obj.Email;
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
