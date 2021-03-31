using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class PermissionGroupViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(64)]
        public string Title { get; set; }
       public bool ShowInMenu { get; set; }
    }
}
