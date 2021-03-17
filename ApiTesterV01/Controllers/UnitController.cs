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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var units = await _unitServices.GetAllAsync();
            return Ok(units);
        }

        /// <summary>
        /// Get Unit name by UnitId or which is assigned to a product by ProductId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="byProduct"></param>
        /// <returns></returns>

        [HttpGet("{id},{byProduct}")]
        public async Task<IActionResult> Get(int id, bool byProduct=false)
        {
            if (!byProduct)
            {
                var units = await _unitServices.GetUnitAsync(id);
                return Ok(units);
            }
            else
            {
                var units = await _unitServices.GetCategoryByProductIdAsync(id);
                return Ok(units);
            }
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
