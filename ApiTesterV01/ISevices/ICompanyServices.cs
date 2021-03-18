using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface ICompanyServices
    {
        Task<IEnumerable<CompanyViewModel>> GetAllAsync();
        Task<CompanyViewModel> GetCompanyByIdAsync(int id);
        Task<IEnumerable<CompanyViewModel>> GetAllByCompanyOwnerIdAsync(int companyOwnerId);
        Task<IEnumerable<CompanyViewModel>> GetAllByUserIdAsync(string userId);
        Task<IEnumerable<CompanyViewModel>> GetAllByCityIdAsync(int cityId);
        Task AddNewAsync(CompanyViewModel model);
        Task UpdateCompanyInfoByIdAsync(CompanyViewModel model);
        Task DeleteCompanyByIdAsync(int id);
        Task DeleteCompanyByCompanyOwnerIdAsync(int companyOwnerId);
        Task DeleteCompanyByUserIdAsync(string userid);

    }
}
