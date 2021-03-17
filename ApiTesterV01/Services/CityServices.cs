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
    public class CityServices: ICityServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public CityServices(APITesterDBContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Gets : All , By Id
        public async Task<IEnumerable<CityViewModel>> GetAllAsync()
        {
            var cities = await _context.City.AsNoTracking().ToListAsync();
            var cityModel = _mapper.Map<IEnumerable<CityViewModel>>(cities);
            return cityModel;
        }
        public async Task<CityViewModel> GetCityAsync(int id)
        {
            var city = await _context.City.Where(o => o.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var cityModel = _mapper.Map<CityViewModel>(city);
            return cityModel;
        }
        #endregion

        #region Add
        public async Task AddNewAsync(CityViewModel model)
        {
            var city = _mapper.Map<City>(model);
            await _context.AddAsync<City>(city);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async Task UpdateCityAsync(CityViewModel model)
        {
            var city = await _context.City.Where(o => o.Id == model.Id).SingleOrDefaultAsync();
            city.Name = model.Name;
            city.ProvinceName = model.ProvinceName;
            await _context.SaveChangesAsync();

        }
        #endregion

        #region Delete
        public async Task DeleteCityAsync(int id)
        {
            var city = await  _context.City.Where(o => o.Id == id).SingleOrDefaultAsync();
            _context.Remove(city);
            await _context.SaveChangesAsync();
        }
        #endregion

       
    }
}
