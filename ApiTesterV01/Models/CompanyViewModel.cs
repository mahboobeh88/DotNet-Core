using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class CompanyViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string AccountNumber { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(10)]
        public string RegisterDateTime { get; set; }
        public short Status { get; set; }
        [Required]
        public long CompanyOwnerId { get; set; }
        public short CityId { get; set; }
    }
}
