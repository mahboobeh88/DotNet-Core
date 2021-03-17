using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IFactoryServices
    {
        Task<IEnumerable<FactoryViewModel>> GetAllAsync();
        Task<IEnumerable<FactoryViewModel>> GetAllByCityIdAsync(int cityId);
        Task<FactoryViewModel> GetFactoryByIdAsync(int id );
        Task AddnewAsync(FactoryViewModel model);

        Task UpdateFactoryByIdAsync(FactoryViewModel model);
        Task DeleteFactoryByIdAsync(int id);
    }
}
