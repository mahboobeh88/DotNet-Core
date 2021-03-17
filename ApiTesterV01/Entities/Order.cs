using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public float TotalDiscount { get; set; }
        public short Status { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public string DeliveredAddress { get; set; }
        public string Mobile { get; set; }
        [ForeignKey("Payment")]
        public long PaymentId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? RefundDate { get; set; }
        public virtual Company Company { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
