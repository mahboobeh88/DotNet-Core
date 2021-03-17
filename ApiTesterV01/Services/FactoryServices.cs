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
    public class FactoryServices : IFactoryServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public FactoryServices(APITesterDBContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Gets : All , By Id, ByCityId 
        public async Task<IEnumerable<FactoryViewModel>> GetAllAsync()
        {
            var factories = await _context.Factory.AsNoTracking().ToListAsync();
            var factoryModel = _mapper.Map<IEnumerable<FactoryViewModel>>(factories);
            return factoryModel;
        }
        public async Task<IEnumerable<FactoryViewModel>> GetAllByCityIdAsync(int cityId)
        {
            var factories = await _context.Factory.Where( f => f.CityId !=null && f.CityId == cityId).AsNoTracking().ToListAsync();
            var factoryModel = _mapper.Map<IEnumerable<FactoryViewModel>>(factories);
            return factoryModel;
        }
        public async Task<FactoryViewModel> GetFactoryByIdAsync(int id)
        {
            var factory = await _context.Factory.Where(f => f.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var factoryModel = _mapper.Map<FactoryViewModel>(factory);
            return factoryModel;
        }
        #endregion
        #region Add
        public async Task AddnewAsync(FactoryViewModel model)
        {
            var factory = _mapper.Map<Factory>(model);
            await _context.AddAsync(factory);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async Task UpdateFactoryByIdAsync(FactoryViewModel model)
        {
            var factory = await _context.Factory.Where(f => f.Id == model.Id).SingleOrDefaultAsync();
            factory.CityId = model.CityId == 0 ? null:model.CityId ;
            factory.Address = model.Address;
            factory.Name = model.Name;
            factory.Name = model.PhoneNumber;
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Delete
        public async Task DeleteFactoryByIdAsync(int id)
        {
            var factory = await _context.Factory.Where(f => f.Id == id).SingleOrDefaultAsync();
            _context.Remove(factory);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
