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

    public class OrderController : BaseController
    {
        private IOrderServices _orderServices;
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        #region Gets:All , By CompanyId , By CustomerId , By RegDate, By Id
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _orderServices.GetAllAsync();
            return Ok(orders);
        }
        [HttpGet("ByCompany/{companyId}")]
        public async Task<IActionResult> GetByCompanyAsync(int companyId)
        {
            var orders = await _orderServices.GetOrderByCompanyIdAsync(companyId);
            return Ok(orders);
        }
        [HttpGet("ByCustomer/{customerId}")]
        public async Task<IActionResult> GetByCustomerAsync(int customerId)
        {
            var orders = await _orderServices.GetOrderByCustomerIdAsync(customerId);
            return Ok(orders);
        }
        [HttpGet("ByRegDate/{startDate} , {endDate}")]
        public async Task<IActionResult> GetByRegDateAsync(string startDate, string endDate)
        {
            var orders = await _orderServices.GetOrderByRegDateAsync(startDate, endDate);
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var order = await _orderServices.GetOrderByIdAsync(id);
            return Ok(order);
        }

        #endregion


        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(OrderViewModel model)
        {
            await _orderServices.AddNewAsync(model);
            return Ok();
        }
        #endregion
        #region Put
        [HttpPut]
        public async Task<IActionResult> Put(OrderViewModel model)
        {
            await _orderServices.UpdateOrderByIdAsync(model);
            return Ok();
        }
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderServices.DeleteOrderByIdAsync(id);
            return Ok();
        }
        #endregion
    }
}
