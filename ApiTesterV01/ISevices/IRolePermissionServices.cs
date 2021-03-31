using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IRolePermissionServices
    {
        Task<ICollection<object>> GetAllAsync();
        Task<object> GetRolePermissionByIdAsync(int rolePermissionId);
        Task AddNewAsync(RolePermissionViewModel model);
         Task UpdateRolePermissionAsync(RolePermissionViewModel model);
        Task DeleteRolePermissionByIdAsync(int id);
        Task DeleteRolePermissionByRoleIdAsync(int roleId);
        Task DeleteRolePermissionByPermissionIdAsync(int permissionId);
    }
}
