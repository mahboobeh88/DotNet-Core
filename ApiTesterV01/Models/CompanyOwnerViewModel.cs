using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class CompanyOwnerViewModel
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
        [MaxLength(11)]
        public string MobileNo { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public short Status { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public short? CityId { get; set; }
    }
}
