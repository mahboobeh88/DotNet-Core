using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public short Status { get; set; }
        public long CompanyOwnerId { get; set; }
        public short CityId { get; set; }
        public virtual City City { get; set; }
        public virtual CompanyOwner CompanyOwner { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual  StoreHouse StoreHouse { get; set; }
    }
}
