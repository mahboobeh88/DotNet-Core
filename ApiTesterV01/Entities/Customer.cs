using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public short Status { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime RegisterdateTime { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("City")]
        public short CityId { get; set; }
        public virtual City City { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
