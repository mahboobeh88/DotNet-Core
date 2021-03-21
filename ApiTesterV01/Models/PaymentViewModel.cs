using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class PaymentViewModel
    {
        public long Id { get; set; }
        [Required]
        public long CustomerId { get; set; }
        [Required]
        public long OrderId { get; set; }
        [Required]
        [MaxLength(30)]
        public string SourceCreditCard { get; set; }
        [Required]
        [MaxLength(30)]
        public string DestinationCreditCard { get; set; }
        [StringLength(10)]
        public string PaymentDate { get; set; }
        public short Status { get; set; }
        [MaxLength(50)]
        public string RRN { get; set; }
        public decimal Price { get; set; }
    }
}
