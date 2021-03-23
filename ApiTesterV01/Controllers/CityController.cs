using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Controllers
{

    public class CityController : BaseController
    {
        private ICityServices _cityServices;
        public CityController(ICityServices cityServices)
        {
            _cityServices = cityServices;
        }

        #region Get : All , By Id
        /// <summary>
        /// Get All Cities Exists In DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var cities = await _cityServices.GetAllAsync();
            if (cities.Count() >= 1) return Ok(cities);
            return Ok();
        }

        /// <summary>
        /// Get City Info By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var city = await _cityServices.GetCityAsync(id);
           if (city != null) return Ok(city);
            return Ok();
        }
        #endregion


        #region Post
        /// <summary>
        /// Insert New City
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CityViewModel model)
        {
            await _cityServices.AddNewAsync(model);
            return Ok();
        }
        #endregion


        #region Put
        /// <summary>
        /// Update a city Info 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(CityViewModel model)
        {
            await _cityServices.UpdateCityAsync(model);
            return Ok();
        }
        #endregion


        #region Delete
        /// <summary>
        /// Delete a city 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id )
        {
            await _cityServices.DeleteCityAsync(id);
            return Ok();
        }
        #endregion


    }
}
