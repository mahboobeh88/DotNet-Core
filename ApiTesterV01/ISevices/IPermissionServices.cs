using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IPermissionServices
    {
        Task<ICollection<PermissionViewModel>> GetAllAsync();
        Task<PermissionViewModel> GetPermissionAsync(int id);

        Task AddNewAsync(PermissionViewModel model);
        Task UpdatePermissionAsync(PermissionViewModel model);
        Task DeletePermissionAsync(int id);
    }
}
