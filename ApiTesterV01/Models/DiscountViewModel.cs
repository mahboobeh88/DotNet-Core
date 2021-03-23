using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class DiscountViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(0, 100)]
        public float? Percent { get; set; }

        public float? Price { get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        public string? ShamsiStartDate { get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        public string? ShamsiEndDate { get; set; }

    }
}
