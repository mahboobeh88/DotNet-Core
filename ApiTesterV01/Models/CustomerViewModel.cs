using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class CustomerViewModel
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(13)]
        public string NationalId { get; set; }
        [StringLength(11)]
        public string Mobile { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [StringLength(10)]
        public string BirthDate { get; set; }
        public short Status { get; set; }
        [MaxLength(30)]
        public string CreditCardNumber { get; set; }
        [StringLength(10)]
        public string RegisterdateTime { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public short CityId { get; set; }
    }
}
