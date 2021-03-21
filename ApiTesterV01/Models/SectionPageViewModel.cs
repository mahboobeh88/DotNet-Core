using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class SectionPageViewModel
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public short SectionType { get; set; }
        [Required]
        public long PageId { get; set; }
        public long? MediaId { get; set; }
        [MaxLength(500)]
        public string ContentText { get; set; }
    }
}
