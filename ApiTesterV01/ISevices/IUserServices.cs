using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IUserServices
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetUserByUserNameAsync(string userName);
        Task<UserViewModel> GetUserByIdAsync(string id);
        Task AddNewAsync(UserViewModel model);
        Task UpdateUserByUserNameAsync(UserViewModel model);
        Task UpdateUserByIdAsync(UserViewModel model);
        Task DeleteUserByUserNameAsync(string userName);
        Task DeleteUserByIdAsync(string id);

    }
}
