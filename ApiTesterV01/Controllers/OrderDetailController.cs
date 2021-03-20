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
  
    public class OrderDetailController : BaseController
    {
        private IOrderDetailServices _orderDetailServices;
        public OrderDetailController(IOrderDetailServices orderDetailServices)
        {
            _orderDetailServices = orderDetailServices;
        }

        #region Gets: All , ByCustomer , ByFactory , ById ,By OrderId , By ProductId
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var odDetails = await _orderDetailServices.GetAllAsync();
            return Ok(odDetails);
        }
        [HttpGet("ByCustomer/{customerId}")]
        public async Task<IActionResult> GetByCustomerIdAsync(int customerId)
        {
            var odDetails = await _orderDetailServices.GetByCustomerIdAsync(customerId);
            return Ok(odDetails);
        }
        [HttpGet("ByFacory/{factoryId}")]
        public async Task<IActionResult> GetByFactoryIdAsync(int factoryId)
        {
            var odDetails = await _orderDetailServices.GetByFactoryIdAsync(factoryId);
            return Ok(odDetails);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var odDetails = await _orderDetailServices.GetByIdAsync(id);
            return Ok(odDetails);
        }

        [HttpGet("ByOrder/{orderId}")]
        public async Task<IActionResult> GetByOrderIdAsync(int orderId)
        {
            var odDetails = await _orderDetailServices.GetByOrderIdAsync(orderId);
            return Ok(odDetails);
        }

        [HttpGet("ByProduct/{productId}")]
        public async Task<IActionResult> GetByProductIdAsync(int productId)
        {
            var odDetails = await _orderDetailServices.GetByProductIdAsync(productId);
            return Ok(odDetails);
        }

        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(OrderDetailViewModel model)
        {
             await _orderDetailServices.AddNewAsync(model);
            return Ok();
        }
        #endregion
        #region Put
        [HttpPut]
        public async Task<IActionResult> Put(OrderDetailViewModel model)
        {
            await _orderDetailServices.UpdateOrderDetailByIdAsync(model);
            return Ok();
        }
        #endregion
        #region Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderDetailServices.DeleteOrderDetailByIdAsync(id);
            return Ok();
        }
        #endregion
    }
}
