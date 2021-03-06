using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class OrderDetail
    {
        public long Id { get; set; }
        [ForeignKey("Order")]
        public long OrderId { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public int ProductDiscountId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Unit ProductUnit { get; set; }
        public virtual ProductDiscount ProductDiscount { get; set; }
    }
}
