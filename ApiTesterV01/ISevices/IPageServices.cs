using ApiTesterV01.Entities;
using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IPageServices
    {
        Task<IEnumerable<PageViewModel>> GetAllAsync();
        Task<IEnumerable<PageViewModel>> GetByCompanyIdAsync(int companyId);
        Task<IEnumerable<PageViewModel>> GetByPageTypeAsync(int type);
        Task<PageViewModel> GetByIdAsync(int id);

        Task AddNewAsync(PageViewModel model);
        Task UpdatePageByIdAsync(PageViewModel model);
        Task DeletePageByIdAsync(int id);
        Task DeletePagesByCompanyAsync(int companyId);
    }
}
