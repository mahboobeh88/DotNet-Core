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
    public class OrderServices : IOrderServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public OrderServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
        {
            var orders = await _context.Order.AsNoTracking().ToListAsync();
            var OrderModel = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return OrderModel;
        }
        public async Task<IEnumerable<OrderViewModel>> GetOrderByCompanyIdAsync(int companyId)
        {
            var orders = await _context.Order.Where(o => o.CompanyId == companyId).AsNoTracking().ToListAsync();
            var OrderModel = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return OrderModel;

        }
        public async Task<IEnumerable<OrderViewModel>> GetOrderByCustomerIdAsync(int customerId)
        {
            var orders = await _context.Order.Where(o => o.CustomerId == customerId).AsNoTracking().ToListAsync();
            var OrderModel = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return OrderModel;
        }
        public async Task<IEnumerable<OrderViewModel>> GetOrderByRegDateAsync(string startDate, string endDate)
        {
            var orders = await _context.Order
                .Where(o => startDate.Trim() == "" || o.RegisterDateTime >= startDate.ToMiladi())
                .Where(o => endDate.Trim() == "" || o.RegisterDateTime <= endDate.ToMiladi())
                .AsNoTracking()
                .ToListAsync();
            if (orders.Count == 0) throw new Exception($"رکوردی در بازه ی {startDate} و {endDate} یافت نشد.");
            var OrderModel = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return OrderModel;
        }
        public async Task<OrderViewModel> GetOrderByIdAsync(int id)
        {
            var order = await _context.Order.Where(o => o.Id == id).AsNoTracking().SingleOrDefaultAsync();
            if (order == null) throw new Exception($"رکوردبا شناسه{id.ToString()} یافت نشد");
            var OrderModel = _mapper.Map<OrderViewModel>(order);
            return OrderModel;
        }

        public async Task AddNewAsync(OrderViewModel model)
        {
            var order = _mapper.Map<Order>(model);
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderByIdAsync(OrderViewModel model)
        {
            var order = await _context.Order.Where(o => o.Id == model.Id).SingleOrDefaultAsync();
            if (order != null)
            {
                order.Mobile = model.Mobile;
                order.PaymentId = model.PaymentId;
                order.RefundDate = (DateTime)(model.RefundDate.ToMiladi());
                order.RegisterDateTime = (DateTime)(model.RegisterDateTime.ToMiladi());
                order.Status = model.Status;
                order.TotalPrice = model.TotalPrice;
                order.TotalDiscount = model.TotalDiscount;
                order.DeliveryDate = (DateTime)(model.DeliveryDate.ToMiladi());
                order.DeliveredAddress = model.DeliveredAddress.Trim();
                order.CompanyId = model.CompanyId;
                order.CustomerId = model.CustomerId;
                await _context.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            else throw new Exception("رکوردی برای بروزرسانی یافت نشد");
        }
        public async Task DeleteOrderByIdAsync(int id)
        {
            var order = await _context.Order.Where(o => o.Id == id).SingleOrDefaultAsync();
            if (order != null)
            {
                _context.Remove(order);
                await _context.SaveChangesAsync();
            }
            else
                throw new Exception("رکوردی برای حذف یافت نشد");
        }


    }
}
