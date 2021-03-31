using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IRoleServices
    {
        Task<ICollection<RoleViewModel>> GetAllAsync();
        Task<RoleViewModel> GetRoleAsync(int id);

        Task AddNewAsync(RoleViewModel model);
        Task UpdateRoleAsync(RoleViewModel model);
        Task DeleteRoleAsync(int id);
    }
}
