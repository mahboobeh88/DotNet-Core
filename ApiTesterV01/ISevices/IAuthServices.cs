using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IAuthServices
    {
        Task<object> LoginAsync(LoginViewModel model);
        Task<object> CreateNewToken(UserViewModel model);
        Task<UserTokenViewModel> UserTokenManagementAsync(UserViewModel model);
        Task<object> CreateNewTokenWithRToken(Guid userId, string refreshToken);
    }
}
