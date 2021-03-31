using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IPermissionGroupServices
    {
        Task<ICollection<PermissionGroupViewModel>> GetAllAsync();
        Task<PermissionGroupViewModel> GetPermissionGroupAsync(int id);

        Task AddNewAsync(PermissionGroupViewModel model);
        Task UpdatePermissionGroupAsync(PermissionGroupViewModel model);
        Task DeletePermissionGroupAsync(int id);
    }
}
