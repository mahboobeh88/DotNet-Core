using ApiTesterV01.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class PageViewModel
    {
        [Key]
        public long Id { get; set; }
        public long CompanyId { get; set; }
        [MaxLength(50)]
        public string PageName { get; set; }
        public short PageType { get; set; }
    }
}
