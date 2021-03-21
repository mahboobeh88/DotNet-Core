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
    public class StoreHouseServices : IStoreHouseServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public StoreHouseServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #region Get : All , By Id , By Product Id , By Company Id , 
        public async Task<IEnumerable<StoreHouseViewModel>> GetAllAsync()
        {
            var sHouses = await _context.StoreHouse.AsNoTracking().ToListAsync();
            var sHouseModel = _mapper.Map<IEnumerable<StoreHouseViewModel>>(sHouses);
            return sHouseModel;
        }
        public async Task<IEnumerable<StoreHouseViewModel>> GetByProductIdAsync(int productId , int companyId)
        {
            var sHouses = await _context.StoreHouse.Where(s => s.ProductId == productId && s.ComapnyId == companyId).AsNoTracking().ToListAsync();
            var sHouseModel = _mapper.Map<IEnumerable<StoreHouseViewModel>>(sHouses);
            return sHouseModel;
        }
        public async Task<StoreHouseViewModel> GetByIdAsync(int id)
        {
            var sHouse = await _context.StoreHouse.Where(s => s.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var sHouseModel = _mapper.Map<StoreHouseViewModel>(sHouse);
            return sHouseModel;
        }
        public async Task<StoreHouseViewModel> GetByCompanyIdAsync(int companyId)
        {
            var sHouse = await _context.StoreHouse.Where(s => s.ComapnyId == companyId).AsNoTracking().SingleOrDefaultAsync();
            var sHouseModel = _mapper.Map<StoreHouseViewModel>(sHouse);
            return sHouseModel;
        }
        #endregion

        #region Add
        public async Task AddNewAsync(StoreHouseViewModel model)
        {
            var sHouse = _mapper.Map<StoreHouse>(model);
            await _context.AddAsync(sHouse);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task UpdateStoreHouseByIdAsync(StoreHouseViewModel model)
        {
            var sHouse = await _context.StoreHouse.Where(s => s.Id == model.Id).SingleOrDefaultAsync();
            if (sHouse != null)
            {
                sHouse.FirstInventory = model.FirstInventory;
                sHouse.ComapnyId = model.ComapnyId;
                sHouse.InventoryEndDateTime = (model.InventoryEndDateTime.Trim() != string.Empty ? (DateTime)model.InventoryEndDateTime.ToMiladi() : null);
                sHouse.InventoryStartDateTime = (DateTime)model.InventoryStartDateTime.ToMiladi();
                sHouse.ProductId = model.ProductId;
                sHouse.Status = model.Status;
                sHouse.UnitId = model.UnitId;
                await _context.SaveChangesAsync();
            }
        }
        #endregion
        #region Delete : By Id , By CompanyId
        public async Task DeleteStoreHouseByIdAsync(int id)
        {
            var sHouse = await _context.StoreHouse.Where(s => s.Id == id).SingleOrDefaultAsync();
            if (sHouse != null)
            {
                _context.Remove(sHouse);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteByCompanyIdAsync(int companyId)
        {
            var sHouses = await _context.StoreHouse.Where(s => s.ComapnyId == companyId).ToListAsync();
            if (sHouses.Count != 0)
            {
                _context.RemoveRange(sHouses);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
