using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IUnitServices
    {
        Task<IEnumerable<UnitViewModel>> GetAllAsync();
        Task<UnitViewModel> GetUnitAsync(int id);
        Task<object> GetCategoryByProductIdAsync(int productId);
        Task AddNewAsync(UnitViewModel model);
        Task UpdateUnitAsync(UnitViewModel newModel);
        Task DeleteByIdAsync(int id);
    }
}
