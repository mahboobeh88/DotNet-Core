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
            if(odDetails.Count() >= 1) return Ok(odDetails);
            return Ok();
        }
        [HttpGet("ByCustomer/{customerId}")]
        public async Task<IActionResult> GetByCustomerIdAsync(int customerId)
        {
            var odDetails = await _orderDetailServices.GetByCustomerIdAsync(customerId);
            if (odDetails.Count() >= 1) return Ok(odDetails);
            return Ok();
        }
        [HttpGet("ByFacory/{factoryId}")]
        public async Task<IActionResult> GetByFactoryIdAsync(int factoryId)
        {
            var odDetails = await _orderDetailServices.GetByFactoryIdAsync(factoryId);
            if (odDetails.Count() >= 1) return Ok(odDetails);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var odDetail = await _orderDetailServices.GetByIdAsync(id);
            if (odDetail!= null) return Ok(odDetail);
            return Ok();
        }

        [HttpGet("ByOrder/{orderId}")]
        public async Task<IActionResult> GetByOrderIdAsync(int orderId)
        {
            var odDetails = await _orderDetailServices.GetByOrderIdAsync(orderId);
            if (odDetails.Count() >= 1) return Ok(odDetails);
            return Ok();
        }

        [HttpGet("ByProduct/{productId}")]
        public async Task<IActionResult> GetByProductIdAsync(int productId)
        {
            var odDetails = await _orderDetailServices.GetByProductIdAsync(productId);
            if (odDetails.Count() >= 1) return Ok(odDetails);
            return Ok();
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
