using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class ProductDiscount
    {
        public int Id { get; set; }
        public long? ProductId { get; set; }
        public int DiscountId { get; set; }
        public long? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
