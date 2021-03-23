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

    public class CompanyOwnerController : BaseController
    {
        private ICompanyOwnerServices _companyOwnerServices;
        public CompanyOwnerController(ICompanyOwnerServices companyOwnerServices)
        {
            _companyOwnerServices = companyOwnerServices;
        }

        #region Gets : All , By Id or By CompanyId
        /// <summary>
        /// Get All CompanyOwners In DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var companyOwners = await _companyOwnerServices.GetAllAsync();
            if (companyOwners.Count() >= 1) return Ok(companyOwners);
            return Ok();
        }
        /// <summary>
        /// Get CompanyOwner Info By Id or By CompanyId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByOwnerIdAsync(int id)
        {
            var companyOwner = await _companyOwnerServices.GetCompanyOwnerByIdAsync(id);
            if (companyOwner != null) return Ok(companyOwner);
            return Ok();
        }
        /// <summary>
        /// Get CompanyOwner Info By Id or By CompanyId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ByCompanyId/{id}")]
        public async Task<IActionResult> GetByCompanyIdAsync(int id)
        {
            var companyOwner = await _companyOwnerServices.GetCompanyOwnerByCompanyIdAsync(id);
            if (companyOwner != null) return Ok(companyOwner);
            return Ok();
        }

        #endregion


        #region Post
        /// <summary>
        /// Insert New CompanyOwner
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CompanyOwnerViewModel model)
        {
            await _companyOwnerServices.AddNewAsync(model);
            return Ok();
        }
        #endregion

        #region Put
        [HttpPut]
        public async Task<IActionResult> Put(CompanyOwnerViewModel model)
        {
            await _companyOwnerServices.UpdateCompanyOwnerByIdAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyOwnerServices.DeleteCompanyOwnerByIdAsync(id);
            return Ok();
        }
        #endregion
    }
}
