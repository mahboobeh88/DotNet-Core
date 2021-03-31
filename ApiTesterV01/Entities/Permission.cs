using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public ActionType ActionType { get; set; }
        public bool ShowInMenu { get; set; }
        public int? PermissionGroupId { get; set; }
        public PermissionGroup PermissionGroup { get; set; }

    }
}
