using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class RolePermissionViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int PermissionId { get; set; }
    }
    public class RolePermissionInfo
    {
        public string Title { get; set; }
        public string Route { get; set; }
        public string ActionType { get; set; }
        public string RoleName { get; set; }
        public string PermissionGroup { get; set; }
    }
}
