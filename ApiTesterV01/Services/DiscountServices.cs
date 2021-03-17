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
    public class DiscountServices : IDiscountServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public DiscountServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        #region Get : All , By Id, By Start-EndDate Filtering
        public async Task<IEnumerable<DiscountViewModel>> GetAllAsync()
        {
            var discounts = await _context.Discount.AsNoTracking().ToListAsync();
            var discountModel = _mapper.Map<IEnumerable<DiscountViewModel>>(discounts);
            return discountModel;
        }
        public async Task<DiscountViewModel> GetDiscountByIdAsync(int Id)
        {
            var discount = await _context.Discount.Where(o => o.Id == Id).AsNoTracking().SingleOrDefaultAsync();
            var discountModel = _mapper.Map<DiscountViewModel>(discount);
            return discountModel;
        }
        public async Task<IEnumerable<DiscountViewModel>> GetDiscountByDateAsync(string _StartDate, string _EndDate)
        {
            try
            {
                var discounts = await _context.Discount
               .Where(s => _StartDate == null || s.StartDate ==null ||  s.StartDate >= (DateTime)_StartDate.ToMiladi())
               .Where(e => _EndDate == null || e.EndDate==null || e.EndDate >= (DateTime)_EndDate.ToMiladi())
               .ToListAsync();

                var discountModel = _mapper.Map<IEnumerable<DiscountViewModel>>(discounts);
                return discountModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Add
        public async Task AddNewAsync(DiscountViewModel model)
        {
            var discount = _mapper.Map<Discount>(model);
            await _context.AddAsync(discount);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async Task UpdateDiscountByIdAsync(DiscountViewModel model)
        {
            var discount = await _context.Discount.Where(o => o.Id == model.Id).SingleOrDefaultAsync();
            discount.Name = model.Name;
            discount.Percent = model.Percent;
            discount.Price = model.Price;
            discount.EndDate = (model.ShamsiEndDate.Trim() == string.Empty ? null :(DateTime)(model.ShamsiEndDate).ToMiladi());
            discount.StartDate = (model.ShamsiStartDate.Trim() == string.Empty ? null : (DateTime)(model.ShamsiStartDate).ToMiladi());
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public async Task DeleteDiscountByIdAsync(int id)
        {
            var discount = await _context.Discount.Where(o => o.Id == id).SingleOrDefaultAsync();
            _context.Remove(discount);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
