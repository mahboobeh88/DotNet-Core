using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IStoreHouseServices
    {
        Task<IEnumerable<StoreHouseViewModel>> GetAllAsync();
        Task<IEnumerable<StoreHouseViewModel>> GetByProductIdAsync(int productId , int companyId);
        Task<StoreHouseViewModel> GetByIdAsync(int id);
        Task<StoreHouseViewModel> GetByCompanyIdAsync(int companyId);
        Task AddNewAsync(StoreHouseViewModel model);
        Task UpdateStoreHouseByIdAsync(StoreHouseViewModel model);
        Task DeleteStoreHouseByIdAsync(int id);
        Task DeleteByCompanyIdAsync(int companyId);

    }
}
