using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IOrderDetailServices
    {
        Task<IEnumerable<OrderDetailViewModel>> GetAllAsync();
        Task<IEnumerable<OrderDetailViewModel>> GetByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderDetailViewModel>> GetByCustomerIdAsync(int customerId);
        Task<IEnumerable<OrderDetailViewModel>> GetByProductIdAsync(int productId);
        Task<IEnumerable<OrderDetailViewModel>> GetByFactoryIdAsync(int factoryId);
        Task<OrderDetailViewModel> GetByIdAsync(int odDetailId);

        Task AddNewAsync(OrderDetailViewModel model);
        Task UpdateOrderDetailByIdAsync(OrderDetailViewModel model);
        Task DeleteOrderDetailByIdAsync(int id);
    }
}
