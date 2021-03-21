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
    
    public class StoreHouseController : BaseController
    {
        private IStoreHouseServices _storeHouseServices;
        public StoreHouseController(IStoreHouseServices storeHouseServices)
        {
            _storeHouseServices = storeHouseServices;
        }


        #region Gets
        /// <summary>
        /// Get All StoreHouses In DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var sHouses = await _storeHouseServices.GetAllAsync();
            return Ok(sHouses);
        }
        /// <summary>
        /// Get StoreHouse By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sHouse = await _storeHouseServices.GetByIdAsync(id);
            return Ok(sHouse);
        }
        /// <summary>
        /// Get entire StoreHouse By product Id for a company
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("ByProduct/{productId}, {companyId}")]
        public async Task<IActionResult> GetByProductAsync(int productId , int companyId)
        {
            var sHouses = await _storeHouseServices.GetByProductIdAsync(productId , companyId);
            return Ok(sHouses);
        }
        /// <summary>
        /// Get entire StoreHouse By CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("ByCompany/{companyId}")]
        public async Task<IActionResult> GetByCompanyAsync(int companyId)
        {
            var sHouse = await _storeHouseServices.GetByCompanyIdAsync( companyId);
            return Ok(sHouse);
        }
        #endregion

        #region Post
        /// <summary>
        /// Add New StoreHouse
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(StoreHouseViewModel model)
        {
            await _storeHouseServices.AddNewAsync(model);
            return Ok();
        }
        #endregion

        #region Put
        /// <summary>
        /// Update a StoreHouse By Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(StoreHouseViewModel model)
        {
            await _storeHouseServices.UpdateStoreHouseByIdAsync(model);
            return Ok();
        }
        #endregion
        #region Delete
        /// <summary>
        /// Delete a StoreHouse By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _storeHouseServices.DeleteStoreHouseByIdAsync(id);
            return Ok();
        }
        /// <summary>
        /// Delete StoreHouse Which belong to a Company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteByCompanyAsync(int companyId)
        {
            await _storeHouseServices.DeleteByCompanyIdAsync(companyId);
            return Ok();
        }
        #endregion

    }
}
