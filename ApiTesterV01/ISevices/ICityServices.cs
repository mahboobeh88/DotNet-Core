using ApiTesterV01.Entities;
using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
    public interface ICityServices
    {

        public Task<IEnumerable<CityViewModel>> GetAllAsync();
        public Task<CityViewModel> GetCityAsync(int id);
        public Task AddNewAsync(CityViewModel model);
        public Task UpdateCityAsync(CityViewModel model);
        public Task DeleteCityAsync(int id);
    }
}
