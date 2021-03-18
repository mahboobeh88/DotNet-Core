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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var companyOwners = await _companyOwnerServices.GetAllAsync();
            return Ok(companyOwners);
        }
        /// <summary>
        /// Get CompanyOwner Info By Id or By CompanyId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="byCompanyId"></param>
        /// <returns></returns>
        [HttpGet("id/byCompanyId")]
        public async Task<IActionResult> Get(int id , bool byCompanyId = false)
        {
            if(!byCompanyId)
            {
                var companyOwner = await _companyOwnerServices.GetCompanyOwnerByIdAsync(id);
                return Ok(companyOwner);
            }
            else
            {
                var companyOwner = await _companyOwnerServices.GetCompanyOwnerByCompanyIdAsync(id);
                return Ok(companyOwner);
            }
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
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyOwnerServices.DeleteCompanyOwnerByIdAsync(id);
            return Ok();
        }
        #endregion
    }
}
