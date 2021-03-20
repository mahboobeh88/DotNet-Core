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
    public class OrderDetailServices :IOrderDetailServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public OrderDetailServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Gets: All , By Id, By Product , By FactoryId , By CustomerId , By OrderId
        public async Task<IEnumerable<OrderDetailViewModel>> GetAllAsync()
        {
            var oDetails = await _context.OrderDetail.AsNoTracking().ToListAsync();
            var oDetailModel = _mapper.Map<IEnumerable<OrderDetailViewModel>>(oDetails);
            return oDetailModel;
        }
        public async Task<IEnumerable<OrderDetailViewModel>> GetByOrderIdAsync(int ordarId)
        {
            var oDetails = await _context.OrderDetail.Where(od => od.OrderId == ordarId).AsNoTracking().ToListAsync();
            var oDetailModel = _mapper.Map<IEnumerable<OrderDetailViewModel>>(oDetails);
            return oDetailModel;
        }
        public async Task<IEnumerable<OrderDetailViewModel>> GetByCustomerIdAsync(int customerId)
        {
            var oDetails = await _context.OrderDetail
                .Join(_context.Order
                , od => od.OrderId
                , o => o.Id, (od, o) => new { od, o.CustomerId })
                .Where(r => r.CustomerId == customerId)
                .Select(r => r.od)
                .AsNoTracking()
                .ToListAsync();
            var oDetailModel = _mapper.Map<IEnumerable<OrderDetailViewModel>>(oDetails);
            return oDetailModel;
        }
        public async Task<IEnumerable<OrderDetailViewModel>> GetByProductIdAsync(int productId)
        {
            var oDetails = await _context.OrderDetail.Where(od => od.ProductId == productId).AsNoTracking().ToListAsync();
            var oDetailModel = _mapper.Map<IEnumerable<OrderDetailViewModel>>(oDetails);
            return oDetailModel;
        }
        public async Task<IEnumerable<OrderDetailViewModel>> GetByFactoryIdAsync(int factoryId)
        {
            var oDetails = await _context.OrderDetail
               .Join(_context.Product
               , od => od.ProductId
               , o => o.Id, (od, o) => new { od, o.FactoryId })
               .Where(r => r.FactoryId == factoryId)
               .Select(r => r.od)
               .AsNoTracking()
               .ToListAsync();
            var oDetailModel = _mapper.Map<IEnumerable<OrderDetailViewModel>>(oDetails);
            return oDetailModel;
        }
        public async Task<OrderDetailViewModel> GetByIdAsync(int odDetailId)
        {
            var oDetails = await _context.OrderDetail.Where(od => od.Id == odDetailId).AsNoTracking().SingleOrDefaultAsync();
            var oDetailModel = _mapper.Map<OrderDetailViewModel>(oDetails);
            return oDetailModel;
        }
        #endregion

        #region Add
        public async Task AddNewAsync(OrderDetailViewModel model)
        {
            var odDetail = _mapper.Map<OrderDetail>(model);
            await _context.AddAsync(odDetail);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task UpdateOrderDetailByIdAsync(OrderDetailViewModel model)
        {
            var odDetail = await _context.OrderDetail.Where(od => od.Id == model.Id).SingleOrDefaultAsync();
            if (odDetail != null)
            {
                odDetail.OrderId = model.OrderId;
                odDetail.Price = model.Price;
                odDetail.ProductDiscountId = model.ProductDiscountId;
                odDetail.ProductId = model.ProductId;
                odDetail.TotalPrice = model.TotalPrice;
                odDetail.UnitId = model.UnitId;
                odDetail.DiscountPrice = model.DiscountPrice;
                odDetail.Count = model.Count;
                await _context.SaveChangesAsync();
            }

        }
        #endregion
        #region Delete
        public async Task DeleteOrderDetailByIdAsync(int id)
        {
            var odDetail = await _context.OrderDetail.Where(od => od.Id == id).SingleOrDefaultAsync();
            if (odDetail != null)
            {
                _context.Remove(odDetail);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

    }
}
