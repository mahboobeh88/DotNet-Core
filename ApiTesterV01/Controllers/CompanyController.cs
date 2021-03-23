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

    public class CompanyController : BaseController
    {
        private ICompanyServices _companyServices;
        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        #region Get : All , By CityId , By ownerId , By UserId , By Id
        /// <summary>
        /// Get All Companies Exist In DB
        /// </summary>
        /// <returns></returns>
        [Route("All/")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var companies = await _companyServices.GetAllAsync();
            if (companies.Count() >= 1) return Ok(companies);
            return Ok();
        }
        /// <summary>
        /// Get All Companies By cityId
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>

        [HttpGet("ByCity/{cityId}")]

        public async Task<IActionResult> GetByCityIdAsync(int cityId)
        {
            var companies = await _companyServices.GetAllByCityIdAsync(cityId);
            if (companies.Count() >= 1) return Ok(companies);
            return Ok();
        }

        /// <summary>
        /// Get All Companies By CompanyOwnerId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ByOwner/{id}")]
        public async Task<IActionResult> GetByCompanyOwnerIdAsync(int id)
        {
            var companies = await _companyServices.GetAllByCompanyOwnerIdAsync(id);
            if (companies.Count() >= 1) return Ok(companies);
            return Ok();
        }
        /// <summary>
        /// Get company By CompanyId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var company = await _companyServices.GetCompanyByIdAsync(id);
            if (company != null) return Ok(company);
            return Ok();
        }
        /// <summary>
        /// Get all companies By UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("ByUser/{userid}")]
        public async Task<IActionResult> GetByUserIdAsync(string userId)
        {
            var companies = await _companyServices.GetAllByUserIdAsync(userId);
            if (companies.Count() >= 1) return Ok(companies);
            return Ok();
        }
        #endregion

        #region Post
        /// <summary>
        /// Insert a New Company
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CompanyViewModel model)
        {
            await _companyServices.AddNewAsync(model);
            return Ok();
        }
        #endregion
        #region Put
        /// <summary>
        /// Update a companyInfo By Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(CompanyViewModel model)
        {
            await _companyServices.UpdateCompanyInfoByIdAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Company By CompanyId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("ById/{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            await _companyServices.DeleteCompanyByIdAsync(id);
            return Ok();
        }
        /// <summary>
        /// Delete All Companies Belong to a CompanyOwnerId
        /// </summary>
        /// <param name="companyOwnerId"></param>
        /// <returns></returns>
        [HttpDelete("ByOwnerId/{companyOwnerId}")]
        public async Task<IActionResult> DeleteByCompanyOwnerIdAsync(int companyOwnerId)
        {
            await _companyServices.DeleteCompanyByCompanyOwnerIdAsync(companyOwnerId);
            return Ok();
        }
        /// <summary>
        /// Delete All Companies Belong to a UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("ByUserId/{userId}")]
        public async Task<IActionResult> DeleteByUserIdAsync(string userId)
        {
            await _companyServices.DeleteCompanyByUserIdAsync(userId);
            return Ok();
        }
        #endregion
    }
}
