using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.DTO
{
    public class UserData
    {
        public int id { get; set; }
        public int countryId { get; set; }
        public int regionId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string tcNo { get; set; }
        public string email { get; set; }
        public int sexId { get; set; }
        public DateTime bornYear { get; set; }
        public string phoneNumber { get; set; }
        public string token { get; set; }
    }
}
