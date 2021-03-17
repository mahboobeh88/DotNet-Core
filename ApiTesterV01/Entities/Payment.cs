using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class Payment
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        [ForeignKey("Order")]
        public long OrderId { get; set; }
        public string SourceCreditCard { get; set; }
        public string DestinationCreditCard { get; set; }
        public DateTime PaymentDate { get; set; }
        public short Status { get; set; }
        public string RRN { get; set; }
        public decimal Price { get; set; }
       public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
