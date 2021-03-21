using ApiTesterV01.Controllers;
using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Services
{
    public class PaymentController : BaseController
    {
        private IPaymentServices _paymentServices;
        public PaymentController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }

        #region Gets : All / ById / ByCustomerId / ByOrder / By Date

        /// <summary>
        /// Get All Payments
        /// </summary>
        /// <returns></returns>
        [HttpGet("All/")]
         public async Task<IActionResult> GetAllAsync()
        {
            var payments = await _paymentServices.GetAllAsync();
            return Ok(payments);
        }

        /// <summary>
        /// Get Payment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var payment = await _paymentServices.GetByIdAsync(id);
            return Ok(payment);
        }

        /// <summary>
        /// Get Payment By Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("ByCustomer/{customerId}")]
        public async Task<IActionResult> GetByCustomerIdAsync(int customerId)
        {
            var payment = await _paymentServices.GetByCustomerIdAsync(customerId);
            return Ok(payment);
        }

        /// <summary>
        /// Get Payments By Date Filter
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet("ByDate/{firstDate} , {endDate}")]
        public async Task<IActionResult> GetByDateAsync(string firstDate = "" , string endDate = "")
        {
            var payments = await _paymentServices.GetByDateAsync(firstDate , endDate);
            return Ok(payments);
        }

        /// <summary>
        /// Get Payment By OrderId
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("ByOrder/{orderId}")]
        public async Task<IActionResult> GetByOrderIdAsync(int orderId)
        {
            var payment = await _paymentServices.GetByOrderIdAsync(orderId);
            return Ok(payment);
        }

        #endregion


        #region Post
        /// <summary>
        /// Add New payment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(PaymentViewModel model)
        {
            await _paymentServices.AddNewAsync(model);
            return Ok();
        }
        #endregion


        #region Put
        /// <summary>
        /// Update a payment 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(PaymentViewModel model)
        {
            await _paymentServices.UpdatePaymentByIdAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a payment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentServices.DeletePaymentByIdAsync(id);
            return Ok();
        }
        #endregion
    }
}
