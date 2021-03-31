using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class PermissionGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool ShowInMenu { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
