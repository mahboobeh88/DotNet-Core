using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IDiscountServices
    {
        Task<IEnumerable<DiscountViewModel>> GetAllAsync();
        Task<DiscountViewModel> GetDiscountByIdAsync(int Id);
        Task<IEnumerable<DiscountViewModel>> GetDiscountByDateAsync(string StartDate, string EndDate);
        Task AddNewAsync(DiscountViewModel model);
        Task UpdateDiscountByIdAsync(DiscountViewModel model);
        Task DeleteDiscountByIdAsync(int id);

    }
}
