using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();
        Task<CategoryViewModel> GetCategoryAsync(int id);
        Task<object> GetCategoryByProductIdAsync(int productId);
        Task AddNewAsync(CategoryViewModel model);
        Task UpdateCategoryAsync(CategoryViewModel model);
        Task DeleteCategoryAsync(int id);
    }
}
