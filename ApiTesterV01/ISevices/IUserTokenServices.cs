using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
   public interface IUserTokenServices
    {
        Task<UserTokenViewModel> GetByUserIdAsync(Guid userId);
        Task AddNewAsync(UserTokenViewModel model);
        Task UpdateRefreshTokenByUserIdAsync(UserTokenViewModel model);
        Task DeleteRefreshTokenByUserIdAsync(Guid userId);
    }
}
