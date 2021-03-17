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
    public class UnitServices : IUnitServices
    {
        private IMapper _mapper;
        private APITesterDBContext _context;
        public UnitServices(IMapper mapper, APITesterDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        #region Gets : All , OneById , All By Products
        public async Task<IEnumerable<UnitViewModel>> GetAllAsync()
        {
            var units = await _context.Unit.OrderByDescending(o => o.Id).AsNoTracking().ToListAsync();
            var result = _mapper.Map<IEnumerable<UnitViewModel>>(units);
            return result;
        }
        public async Task<UnitViewModel> GetUnitAsync(int id)
        {
            var unit = await _context.Unit.Where(i => i.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var unitModel = _mapper.Map<UnitViewModel>(unit);
            return unitModel;
        }
        public async Task<object> GetCategoryByProductIdAsync(int productId)
        {
            var units = await (
           from u in _context.Unit
           join p in _context.Product on u.Id equals p.ProductUnitId
           where p.Id == productId
           select new { productName = p.Name, UnitName = u.Name, productId = p.Id }).AsNoTracking().ToListAsync();
            return units;

        }
        #endregion

        #region InsertNew
        public async Task AddNewAsync(UnitViewModel model)
        {
            var unit = _mapper.Map<Unit>(model);
            await _context.AddAsync(unit);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async Task UpdateUnitAsync(UnitViewModel model)
        {
            try
            {
                var NewUnit = await _context.FindAsync<Unit>(model.Id);
                NewUnit.Name = model.Name;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Delete 
        public async Task DeleteByIdAsync(int id)
        {
            try
            {
                var unit = await _context.Unit.Where(i => i.Id == id).AsNoTracking().SingleOrDefaultAsync();
                _context.Remove(unit);
                await _context.SaveChangesAsync();
            }
            catch (Exception )
            {
                throw ;
            }

        }
        #endregion


    }
}
