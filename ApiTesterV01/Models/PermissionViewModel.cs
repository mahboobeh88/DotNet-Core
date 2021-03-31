using ApiTesterV01.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class PermissionViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required , MaxLength(64)]
        public string Title { get; set; }
        [MaxLength(64)]
        public string AreaName { get; set; }
        [Required,MaxLength(64)]
        public string ControllerName { get; set; }
        [Required, MaxLength(64)]
        public string ActionName { get; set; }
        [Required]
        public ActionType ActionType { get; set; }
        public bool ShowInMenu { get; set; }
        public int? PermissionGroupId { get; set; }
    }
}
