using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class CompanyOwner
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string MobileNo { get; set; }
        public DateTime BirthDate { get; set; }
        public short Status { get; set; }
        public Guid UserId { get; set; }
        public short CityId { get; set; }
        public virtual User User { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Company> Companies { get; set; }

    }
}
