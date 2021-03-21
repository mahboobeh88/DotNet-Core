using ApiTesterV01.Common;
using ApiTesterV01.Data;
using ApiTesterV01.Entities;
using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public PaymentServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Gets : All / ByCustomerId / ByDate / ById / ByOrderId
        public async Task<IEnumerable<PaymentViewModel>> GetAllAsync()
        {
            var payments = await _context.Payment.AsNoTracking().ToListAsync();
            var paymnetModel = _mapper.Map<IEnumerable<PaymentViewModel>>(payments);
            return paymnetModel;
        }
        public async Task<IEnumerable<PaymentViewModel>> GetByCustomerIdAsync(int customerId)
        {
            var payments = await _context.Payment.Where(p => p.CustomerId == customerId).AsNoTracking().ToListAsync();
            var paymnetModel = _mapper.Map<IEnumerable<PaymentViewModel>>(payments);
            return paymnetModel;
        }
        public async Task<IEnumerable<PaymentViewModel>> GetByDateAsync(string firstDate, string endDate)
        {
            var payments = await _context.Payment
                .Where(p => (firstDate.Trim() != string.Empty || p.PaymentDate >= firstDate.ToMiladi())
                && (endDate.Trim() != string.Empty || p.PaymentDate <= endDate.ToMiladi()))
                .AsNoTracking()
                .ToListAsync();
            var paymnetModel = _mapper.Map<IEnumerable<PaymentViewModel>>(payments);
            return paymnetModel;
        }
        public async Task<PaymentViewModel> GetByIdAsync(int paymentId)
        {
            var payment = await _context.Payment.Where(p => p.Id == paymentId).AsNoTracking().SingleOrDefaultAsync();
            var paymnetModel = _mapper.Map<PaymentViewModel>(payment);
            return paymnetModel;
        }
        public async Task<PaymentViewModel> GetByOrderIdAsync(int orderId)
        {
            var payment = await _context.Payment.Where(p => p.OrderId == orderId).AsNoTracking().SingleOrDefaultAsync();
            var paymnetModel = _mapper.Map<PaymentViewModel>(payment);
            return paymnetModel;
        }
        #endregion
        #region Add
        public async Task AddNewAsync(PaymentViewModel model)
        {
            var payment = _mapper.Map<Payment>(model);
            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();

        }

        #endregion
        #region Update
        public async Task UpdatePaymentByIdAsync(PaymentViewModel model)
        {
            var payment = await _context.Payment.Where(r => r.Id == model.Id).SingleOrDefaultAsync();
            if (payment != null)
            {
                payment.OrderId = model.OrderId;
                payment.PaymentDate = (DateTime)(model.PaymentDate.ToMiladi());
                payment.RRN = model.RRN.Trim();
                payment.SourceCreditCard = model.SourceCreditCard.Trim();
                payment.Status = model.Status;
                payment.DestinationCreditCard = model.DestinationCreditCard.Trim();
                payment.CustomerId = model.CustomerId;
                payment.Price = model.Price;
                await _context.SaveChangesAsync();
            }
        }

        #endregion
        #region Delete
        public async Task DeletePaymentByIdAsync(int id)
        {
            var payment = await _context.Payment.Where(r => r.Id == id).SingleOrDefaultAsync();
            if (payment != null)
            {
                _context.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
