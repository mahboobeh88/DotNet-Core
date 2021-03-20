using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class OrderViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long CompanyId { get; set; }
        [Required]
        public long CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public float TotalDiscount { get; set; }
        public short Status { get; set; }
        [StringLength(10)]
        public string RegisterDateTime { get; set; }
        [MaxLength(150)]
        public string DeliveredAddress { get; set; }
        [MaxLength(11)]
        public string Mobile { get; set; }
       
        public long PaymentId { get; set; }
        [StringLength(10)]
        public string? DeliveryDate { get; set; }
        [StringLength(10)]
        public string? RefundDate { get; set; }
    }
}
