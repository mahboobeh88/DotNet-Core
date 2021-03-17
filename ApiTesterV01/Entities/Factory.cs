using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public short CityId { get; set; }
        public City City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
