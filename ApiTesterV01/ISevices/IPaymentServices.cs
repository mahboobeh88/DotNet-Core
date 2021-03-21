using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface IPaymentServices
    {
        Task<IEnumerable<PaymentViewModel>> GetAllAsync();
        Task<IEnumerable<PaymentViewModel>> GetByCustomerIdAsync(int customerId);
        Task<IEnumerable<PaymentViewModel>> GetByDateAsync(string firstDate, string endDate);
        Task<PaymentViewModel> GetByIdAsync(int paymentId);
        Task<PaymentViewModel> GetByOrderIdAsync(int orderId);
        Task AddNewAsync(PaymentViewModel model);
        Task UpdatePaymentByIdAsync(PaymentViewModel model);
        Task DeletePaymentByIdAsync(int id);

    }
}
