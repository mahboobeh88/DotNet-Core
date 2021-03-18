using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerViewModel>> GetAllAsync();
        Task<CustomerViewModel> GetCustomerBydIdAsync(int customerId);
        Task<CustomerViewModel> GetCustomerByUserIdAsync(string userId);
        Task<CustomerViewModel> GetCustomerByUserNameAsync(string userName);
        Task<IEnumerable<CustomerViewModel>> GetCustomerByCityIdAsync(int cityId);
        Task<CustomerViewModel> GetCustomerByNationalIdAsync(string NationalId);

        Task AddnewAsync(CustomerViewModel model);
        Task UpdateCustomerInfoAsync(CustomerViewModel model);
        Task DeleteCustomerByIdAsync(int customerId);
    }
}
