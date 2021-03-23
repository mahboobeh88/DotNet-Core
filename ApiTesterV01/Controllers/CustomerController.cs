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

    public class CustomerController : BaseController
    {

        private ICustomerServices _customerServices;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        #region Gets : All , By Id , By UserId, By UserName , By NationalId , By CityId
        /// <summary>
        /// Get All Customers Registered In APITester
        /// </summary>
        /// <returns></returns>
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var customers = await _customerServices.GetAllAsync();
            if (customers.Count() >= 1) return Ok(customers);
            return Ok();
        }
        /// <summary>
        /// Get Customer By CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomeByIdAsync(int customerId)
        {
            var customer = await _customerServices.GetCustomerBydIdAsync(customerId);
            if (customer != null) return Ok(customer);
            return Ok();
        }
        /// <summary>
        /// Get Customer By her/his UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("ByUserId/{userId}")]
        public async Task<IActionResult> GetCustomeByUserIdAsync(string userId)
        {
            var customer = await _customerServices.GetCustomerByUserIdAsync(userId);
            if (customer != null) return Ok(customer);
            return Ok();
        }
        /// <summary>
        ///  Get Customer By her/his UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("ByUserName/{userName}")]
        public async Task<IActionResult> GetCustomeByUserNameAsync(string userName)
        {
            var customer = await _customerServices.GetCustomerByUserIdAsync(userName);
            if (customer != null) return Ok(customer);
            return Ok();
        }
        /// <summary>
        ///  Get Customer By her/his NationalId
        /// </summary>
        /// <param name="nationalId"></param>
        /// <returns></returns>
        [HttpGet("ByNationalId/{nationalId}")]
        public async Task<IActionResult> GetCustomeByNationalIdAsync(string nationalId)
        {
            var customer = await _customerServices.GetCustomerByNationalIdAsync(nationalId);
            if (customer != null) return Ok(customer);
            return Ok();
        }
        /// <summary>
        ///  Get Customers By CityId
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [HttpGet("ByCity/{cityId}")]
        public async Task<IActionResult> GetCustomeByCityIdAsync(int cityId)
        {
            var customers = await _customerServices.GetCustomerByCityIdAsync(cityId);
            if (customers.Count() >= 1) return Ok(customers);
            return Ok();
        }
        #endregion

        #region Post
        /// <summary>
        /// Register New Customer 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CustomerViewModel model)
        {
            await _customerServices.AddnewAsync(model);
            return Ok();
        }
        #endregion

        #region Put
        /// <summary>
        /// Update Customer Info By Customer Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(CustomerViewModel model)
        {
            await _customerServices.UpdateCustomerInfoAsync(model);
            return Ok();
        }
        #endregion
        #region Delete
        /// <summary>
        /// Delete a customer By CustomerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerServices.DeleteCustomerByIdAsync(id);
            return Ok();
        }
        #endregion



    }
}
