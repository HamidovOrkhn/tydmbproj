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
    public class WhatWeDoRepos: ITransactions<WhatWeDoDTO>
    {
        private readonly DatabaseContext _db;
        public WhatWeDoRepos(DatabaseContext db)
        {
            _db = db;
        }

        public bool Add(WhatWeDoDTO obj)
        {
            try
            {
                _db.WhatWeDos.Add(new WhatWeDo
                {
                    Id = obj.Id,
                    Content = obj.Content,
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

        public bool Delete(WhatWeDoDTO obj)
        {
            try
            {
                WhatWeDo data = _db.WhatWeDos.Find(obj.Id);
                _db.WhatWeDos.Remove(data);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public WhatWeDoDTO Get(int Id)
        {
            try
            {
                WhatWeDo data =_db.WhatWeDos.Find(Id);
                WhatWeDoDTO finaldata = new WhatWeDoDTO
                {
                    Id = data.Id,
                    Content = data.Content,
                    LanguageId = data.LanguageId
                };
                return finaldata;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<WhatWeDoDTO> GetAll()
        {
            return null;
        }

        public bool Update(WhatWeDoDTO obj, int Id)
        {
            try
            {
                WhatWeDo data = _db.WhatWeDos.Find(Id);
                data.Content = obj.Content;
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
