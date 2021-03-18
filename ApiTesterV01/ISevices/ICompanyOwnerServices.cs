using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface ICompanyOwnerServices
    {
        Task<IEnumerable<CompanyOwnerViewModel>> GetAllAsync();
        Task<CompanyOwnerViewModel> GetCompanyOwnerByIdAsync(int id);
        Task<CompanyOwnerViewModel> GetCompanyOwnerByCompanyIdAsync(int id);
        Task AddNewAsync(CompanyOwnerViewModel model);

        Task UpdateCompanyOwnerByIdAsync(CompanyOwnerViewModel model);
        Task DeleteCompanyOwnerByIdAsync(int id);

    }
}
