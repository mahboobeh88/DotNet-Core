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
    public class FactoryController : BaseController
    {
        private IFactoryServices _factoryServices;
        public FactoryController(IFactoryServices factoryServices)
        {
            _factoryServices = factoryServices;
        }

        #region Gets : All , By Id , By CityId
        /// <summary>
        /// Get All Factories In DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Factories = await _factoryServices.GetAllAsync();
            return Ok(Factories);
        }

        [HttpGet("id/byCity")]
        public async Task<IActionResult> Get(int id, bool byCity = false)
        {
            if(!byCity)
            {
                var factory = await _factoryServices.GetFactoryByIdAsync(id);
                return Ok(factory);
            }
            else
            {
                var factories = await _factoryServices.GetAllByCityIdAsync(id);
                return Ok(factories);
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// Insert New Factory
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(FactoryViewModel model)
        {
            await _factoryServices.AddnewAsync(model);
            return Ok();
        }
        #endregion

        #region Put
        /// <summary>
        /// Update a factoryInfo 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(FactoryViewModel model)
        {
            await _factoryServices.UpdateFactoryByIdAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            await _factoryServices.DeleteFactoryByIdAsync(id);
            return Ok();
        }
        #endregion

    }
}
