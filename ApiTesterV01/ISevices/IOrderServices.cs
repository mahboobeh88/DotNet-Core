using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IOrderServices
    {
        Task<IEnumerable<OrderViewModel>> GetAllAsync();
        Task<IEnumerable<OrderViewModel>> GetOrderByCompanyIdAsync(int companyId);
        Task<IEnumerable<OrderViewModel>> GetOrderByCustomerIdAsync(int customerId);
        Task<IEnumerable<OrderViewModel>> GetOrderByRegDateAsync(string startDate , string endDate);
        Task<OrderViewModel> GetOrderByIdAsync(int id);

        Task AddNewAsync(OrderViewModel model);
        Task UpdateOrderByIdAsync(OrderViewModel model);
        Task DeleteOrderByIdAsync(int id);
    }
}
