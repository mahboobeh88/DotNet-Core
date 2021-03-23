using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
//using ApiTesterV01.MyFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Controllers
{

    public class UnitController : BaseController
    {

        private IUnitServices _unitServices;
        public UnitController(IUnitServices unitServices)
        {
            _unitServices = unitServices;
        }

        #region Gets : All , By UnitId or By ProductId
        /// <summary>
        /// Get All Units exist in DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var units = await _unitServices.GetAllAsync();
            if (units.Count() >= 1) return Ok(units);
            return Ok();
        }

        /// <summary>
        /// Get Unit name by UnitId 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var unit = await _unitServices.GetUnitAsync(id);
            if (unit != null) return Ok(unit);
            return Ok();
        }
        /// <summary>
        /// Get Unit name by ProductId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        [HttpGet("ByProduct/{productId}")]
        public async Task<IActionResult> GetByProductIdAsync(int productId)
        {
            var unit = await _unitServices.GetCategoryByProductIdAsync(productId);
            if (unit != null) return Ok(unit);
            return Ok();
        }
        #endregion

        #region Post
        /// <summary>
        /// Submit a unit in DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        // [ValidateModel]
        public async Task<IActionResult> Post(UnitViewModel model)
        {
            await _unitServices.AddNewAsync(model);
            return Ok();
        }
        #endregion Post

        #region Put
        /// <summary>
        /// Update a unit (just Name) by UnitId 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(UnitViewModel model)
        {
            await _unitServices.UpdateUnitAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a Unit by UnitId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _unitServices.DeleteByIdAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { errorCode = "100", errorMessage = "because of ForeignKeyStory" });
            }

        }
        #endregion
    }
}
