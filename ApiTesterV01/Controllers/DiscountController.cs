using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ApiTesterV01.Controllers
{

    public class DiscountController : BaseController
    {
        private IDiscountServices _discountServices;
        public DiscountController(IDiscountServices discountServices)
        {
            _discountServices = discountServices;
        }

        #region Gets : All , By Id , Start-EndDateFiltering 
        /// <summary>
        /// Get All Discount In DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var discounts = await _discountServices.GetAllAsync();
            if (discounts.Count() >= 1) return Ok(discounts);
            return Ok();
        }

        /// <summary>
        /// Get Discount By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var discount = await _discountServices.GetDiscountByIdAsync(id);
            if (discount != null) return Ok(discount);
            return Ok();
        }

        /// <summary>
        /// Get Discount By Start-End Date Filtering
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("ByDate/")]
        public async Task<IActionResult> GetByDateFilterAsync(string startDate , string endDate )
        {
            var discounts = await _discountServices.GetDiscountByDateAsync(startDate, endDate);
            if (discounts.Count() >= 1) return Ok(discounts);
            return Ok();
        }


        #endregion

        #region Post
        /// <summary>
        /// Insert New Discount
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(DiscountViewModel model)
        {
            await _discountServices.AddNewAsync(model);
            return Ok();
        }
        #endregion

        #region Put
        /// <summary>
        /// Update a Discount Info
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(DiscountViewModel model)
        {
            await _discountServices.UpdateDiscountByIdAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a Discount From DB By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountServices.DeleteDiscountByIdAsync(id);
            return Ok();
        }
        #endregion

    }
}
